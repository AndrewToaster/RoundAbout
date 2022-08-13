using RoundAbout.Runtime;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Numerics;

namespace VisualRoundAbout
{
    public partial class Visualizer : Form, IMessageFilter
    {
        private const float zoomFactor = 0.25f;
        private bool recreate = false;
        private Bitmap? map = null;
        private float zoomLevel = 1f;
        private float offsetX = 0f;
        private float offsetY = 0f;
        private const float padding = 6f;
        private PointF lastLoc;
        private Point? mouseHold;
        private RbInterpreter? interpreter;
        private ListenWriteStream? listenWriteStream;
        private NestedMemoryStream? inputStream;

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg != NativeCode.Constants.WM_KEYDOWN)
                return false;

            if ((int)m.WParam == NativeCode.Constants.VK_F5)
            {
                ts_btn_PlayPause_Click(ts_btn_PlayPause, null!);
            }
            else if ((int)m.WParam == NativeCode.Constants.VK_F7)
            {
                ts_btn_Next_Click(ts_btn_Next, null!);
            }
            else
            {
                return false;
            }

            return true;
        }

        public Visualizer()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);

            pnl_Draw.SetDoubleBuffered(true);
            lstv_Stack.SetDoubleBuffered(true);
            lstb_Heap.SetDoubleBuffered(true);

            /*
            // Ugly fix for flicker, but works most of the time
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
                | BindingFlags.Instance | BindingFlags.NonPublic, null,
                pnl_Draw, new object[] { true });

            typeof(ListView).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
                | BindingFlags.Instance | BindingFlags.NonPublic, null,
                lstv_Stack, new object[] { true });

            typeof(ListBox).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
                | BindingFlags.Instance | BindingFlags.NonPublic, null,
                lstb_Heap, new object[] { true });
            */
        }

        private void Visualizer_Load(object sender, EventArgs e)
        {
            FitHeader();
        }

        private void ListenWriteStream_OnFlush(byte[] obj)
        {
            txb_StdOut.Invoke(() =>
            {
                txb_StdOut.AppendText(Encoding.UTF8.GetString(obj));
            });
        }

        private void lstv_Stack_Resize(object sender, EventArgs e)
        {
            FitHeader();
        }

        private void FitHeader()
        {
            lstv_Stack.Columns[1].Width = lstv_Stack.Width - 6 - SystemInformation.VerticalScrollBarWidth;
        }

        private void pnl_Draw_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            map = new Bitmap((int)e.Graphics.ClipBounds.Width, (int)e.Graphics.ClipBounds.Height, g);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TranslateTransform(pnl_Draw.Width / 2f, pnl_Draw.Height / 2f);
            g.ScaleTransform(zoomLevel, zoomLevel);
            g.TranslateTransform(offsetX, offsetY);

            if (interpreter != null)
            {
                float x = 0;
                float y = 0;
                float off_y = 0f;

                for (int i = 0; i < interpreter.State.Map.Height; i++)
                {
                    for (int j = 0; j < interpreter.State.Map.Width; j++)
                    {
                        var box = DrawBoxedCharacterPadded(g, interpreter.State.Map.Content[i, j],
                            padding, Font, Brushes.Black, x, y, Brushes.DodgerBlue,
                            interpreter.State.X == j && interpreter.State.Y == i);
                        off_y = box.Height;
                        x += box.Width;
                    }
                    y += off_y;
                    x = 0;
                }
            }
        }

        private RectangleF DrawBoxedCharacterPadded(Graphics g, char letter, float padding,
            Font font, Brush charColor, float x, float y, Brush highlightColor, bool highlight)
        {
            var sX = g.MeasureString("x", Font);
            var sC = g.MeasureString(letter.ToString(), Font);
            var padHalf = padding / 2f;
            var padRect = new RectangleF(-padHalf + x, -padHalf + y, sX.Height + padding, sX.Height + padding);

            if (highlight)
                g.FillRectangle(highlightColor, padRect.X, padRect.Y, padRect.Width, padRect.Height);

            g.DrawString(letter.ToString(), font, charColor,
                MathF.Round(padRect.X + ((padRect.Width - sC.Width) / 2), 4),
                MathF.Round(padRect.Y + ((padRect.Height - sC.Height) / 2), 4));

            return padRect;
        }

        private void pnl_Draw_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                zoomLevel /= 1 - zoomFactor;
            }
            else if (e.Delta < 0)
            {
                zoomLevel *= 1 - zoomFactor;
            }
            // Weird crash
            zoomLevel = Math.Min(5400, zoomLevel);
            pnl_Draw.Invalidate();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (interpreter != null)
            {
                StepInterpreter();
            }
        }

        private void pnl_Draw_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseHold == null)
                return;

            offsetX = lastLoc.X + (e.X - mouseHold.Value.X) / zoomLevel;
            offsetY = lastLoc.Y + (e.Y - mouseHold.Value.Y) / zoomLevel;
            pnl_Draw.Invalidate();
        }

        private void pnl_Draw_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left) && mouseHold == null)
                mouseHold = e.Location;
        }

        private void pnl_Draw_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left) && mouseHold != null)
            {
                lastLoc = new PointF(offsetX, offsetY);
                mouseHold = null;
            }
        }

        private void btn_StackPop_Click(object sender, EventArgs e)
        {
            interpreter?.Stack?.TryPop(out _);
        }

        private void btn_StackPush_Click(object sender, EventArgs e)
        {
            var prompt = new ValuePrompt();
            var result = prompt.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            lstv_Stack.Items.Add(new ListViewItem(new string[]
            {
                "", prompt.Value.ToString()
            }));
            interpreter?.Stack?.Push(prompt.Value);
        }

        private void lstv_Stack_DoubleClick(object sender, EventArgs e)
        {
            if (lstv_Stack.SelectedItems.Count == 0)
                return;

            var item = lstv_Stack.SelectedItems[0];
            int index = lstv_Stack.Items.IndexOf(item);

            MessageBox.Show(item.SubItems[1].Text);
        }

        private void ts_btn_Open_Click(object sender, EventArgs e)
        {
            if (fod_Code.ShowDialog(this) != DialogResult.OK)
                return;

            CreateInterpFromCode(File.ReadAllText(fod_Code.FileName));
            pnl_Draw.Invalidate();

            ts_btn_PlayPause.Enabled = true;
            ts_btn_Next.Enabled = true;
            ts_txb_Speed.Enabled = true;
            ts_btn_MemFlag.Enabled = true;
            ts_lbl_Speed.Enabled = true;
            ts_ddbtn_Direction.Enabled = true;
            ts_ddbtn_Mode.Enabled = true;
            lstb_Heap.Enabled = true;
            lstv_Stack.Enabled = true;
            txb_StdIn.Enabled = true;
            txb_StdOut.Enabled = true;
            btn_StackPop.Enabled = true;
            btn_StackPush.Enabled = true;

            t_Update.Stop();
            UpdatePlayPauseButton(true);

            State_DirectionChanged(interpreter!.Direction);
            State_ModeChanged(interpreter!.Mode);

            lstb_Heap.Items.Clear();
            lstb_Heap.Items.AddRange(interpreter!.Heap.Cells.Select(x => new HeapBoxItem(x.Value, x.Key, lstb_Heap)).ToArray());
            lstb_Heap.Index = interpreter!.Heap.Pointer;

            lstv_Stack.Items.Clear();
            lstv_Stack.Items.AddRange(interpreter!.Stack.Collection.Select(x => new ListViewItem(new string[]
            {
                "", x.ToString()
            })).ToArray());

            txb_StdOut.Clear();
            UpdateMemFlagButton(interpreter!.State.MemFlag);
        }

        private void CreateInterpFromCode(string content)
        {
            string[] lines = content.ReplaceLineEndings("\n").Split('\n');

            int w = 0;
            int h = 0;
            if (lines[0].StartsWith("//"))
            {
                var x = lines[0][2..].Split(',').Select(x => int.Parse(x.Trim())).ToArray();
                (w, h) = (x[0], x[1]);
                lines = lines.Skip(1).ToArray();
            }
            else
            {
                h = lines.Length;
                w = (lines.MaxBy(x => x.Length)?.Length).GetValueOrDefault(0);
            }

            char[,] mapContent = new char[h, w];
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    if (y < lines.Length && x < lines[y].Length)
                        mapContent[y, x] = lines[y][x];
                    else
                        mapContent[y, x] = ' ';
                }
            }
            // Very cursed C:
            var state = new RbState(new(mapContent), new(), new(), false, 0, 0, RoundAbout.Runtime.FlowDirection.Right, RbMode.Traversal);

            if (interpreter != null)
            {
                interpreter.Stack.ItemAdded -= Stack_ItemAdded;
                interpreter.Stack.ItemRemoved -= Stack_ItemRemoved;
                interpreter.Stack.Cleared -= Stack_Cleared;
                interpreter.Stack.ItemSwapped -= Stack_ItemSwapped;
                interpreter.Heap.PointerChanged -= Heap_PointerChanged;
                interpreter.Heap.CellChanged -= Heap_CellChanged;
                interpreter.State.MemFlagChanged -= UpdateMemFlagButton;
                interpreter.State.DirectionChanged -= State_DirectionChanged;
                interpreter.State.ModeChanged -= State_ModeChanged;
            }

            if (listenWriteStream != null)
            {
                listenWriteStream.Close();
                listenWriteStream.Flushed -= ListenWriteStream_OnFlush;
            }

            inputStream?.Close();
            inputStream = new();

            listenWriteStream = new();
            listenWriteStream.Flushed += ListenWriteStream_OnFlush;

            interpreter = new RbInterpreter(state, inputStream, listenWriteStream);
            interpreter.Stack.ItemAdded += Stack_ItemAdded;
            interpreter.Stack.ItemRemoved += Stack_ItemRemoved;
            interpreter.Stack.Cleared += Stack_Cleared;
            interpreter.Stack.ItemSwapped += Stack_ItemSwapped;
            interpreter.Heap.PointerChanged += Heap_PointerChanged;
            interpreter.Heap.CellChanged += Heap_CellChanged;
            interpreter.Heap.Cleared += Heap_Cleared;
            interpreter.State.MemFlagChanged += UpdateMemFlagButton;
            interpreter.State.DirectionChanged += State_DirectionChanged;
            interpreter.State.ModeChanged += State_ModeChanged;
            interpreter.State.MapSymbolChanged += State_MapSymbolChanged;
            interpreter.Map.Resized += Map_Resized;
        }

        private void Heap_Cleared(KeyValuePair<BigInteger, System.Numerics.BigInteger>[] obj)
        {
            lstb_Heap.Items.Clear();
            lstb_Heap.RefreshIndex();
        }

        private void Map_Resized(int arg1, int arg2)
        {
            pnl_Draw.Invalidate();
        }

        private void State_MapSymbolChanged(char arg1, int arg2, int arg3)
        {
            pnl_Draw.Invalidate();
        }

        private void State_ModeChanged(RbMode obj)
        {
            var items = ts_ddbtn_Mode.DropDownItems
                   .Cast<ToolStripItem>()
                   .Where(x => x is ToolStripMenuItem);
            foreach (ToolStripMenuItem item in items)
            {
                item.Checked = item.Tag.Equals((int)obj);
            }
        }

        private void StepInterpreter()
        {
            if (interpreter == null)
                return;

            try
            {
                interpreter.TryStep();
                pnl_Draw.Invalidate();
            }
            catch (RbException ex)
            {
                MessageBox.Show(this, ex.ToString(), "Runtime Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                interpreter.Direction = RoundAbout.Runtime.FlowDirection.None;
                interpreter.Stopped = true;
            }
        }

        private void ts_btn_Next_Click(object sender, EventArgs e)
        {
            StepInterpreter();
        }

        private void State_DirectionChanged(RoundAbout.Runtime.FlowDirection obj)
        {
            var items = ts_ddbtn_Direction.DropDownItems
                .Cast<ToolStripItem>()
                .Where(x => x is ToolStripMenuItem && !x.Tag.Equals(0));
            foreach (ToolStripMenuItem item in items)
            {
                item.Checked = obj.HasFlag((RoundAbout.Runtime.FlowDirection)item.Tag);
            }
        }

        private void Heap_CellChanged(System.Numerics.BigInteger arg1, BigInteger arg2)
        {
            var item = lstb_Heap.Items.Cast<HeapBoxItem>().FirstOrDefault(x => x.Index == arg2);
            if (item != null)
            {
                if (arg1 == System.Numerics.BigInteger.Zero)
                {
                    lstb_Heap.Items.Remove(item);
                }
                else
                {
                    item.Value = arg1;
                    lstb_Heap.RefreshItems();
                }
            }
            else
            {
                lstb_Heap.Items.Add(new HeapBoxItem(arg1, arg2, lstb_Heap));
            }
        }

        private void Heap_PointerChanged(BigInteger obj)
        {
            lstb_Heap.Index = obj;
        }

        private void Stack_ItemSwapped(System.Numerics.BigInteger arg1, System.Numerics.BigInteger arg2)
        {
            (lstv_Stack.Items[^1], lstv_Stack.Items[^2]) = (lstv_Stack.Items[^2], lstv_Stack.Items[^1]);
        }

        private void Stack_Cleared(System.Numerics.BigInteger[] obj)
        {
            lstv_Stack.Items.Clear();
        }

        private void Stack_ItemRemoved(System.Numerics.BigInteger obj)
        {
            lstv_Stack.Items.RemoveAt(lstv_Stack.Items.Count - 1);
        }

        private void Stack_ItemAdded(System.Numerics.BigInteger obj)
        {
            lstv_Stack.Items.Add(new ListViewItem(new string[] { "", obj.ToString() }));
        }

        private void ts_txb_Speed_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(ts_txb_Speed.Text, out int speed))
            {
                MessageBox.Show("Invalid value");
                ts_txb_Speed.Text = t_Update.Interval.ToString();
                return;
            }

            if (speed <= 0)
            {
                MessageBox.Show("Invalid value");
                ts_txb_Speed.Text = t_Update.Interval.ToString();
                return;
            }

            t_Update.Interval = speed;
        }

        private void ts_btn_PlayPause_Click(object sender, EventArgs e)
        {
            if (t_Update.Enabled)
            {
                UpdatePlayPauseButton(true);
                t_Update.Stop();
            }
            else
            {
                UpdatePlayPauseButton(false);
                t_Update.Start();
            }
        }

        private void UpdatePlayPauseButton(bool paused)
        {
            if (paused)
            {
                ts_btn_PlayPause.Image = Properties.Resources.play_button;
                ts_btn_PlayPause.Text = "Play (F5)";
            }
            else
            {
                ts_btn_PlayPause.Image = Properties.Resources.pause;
                ts_btn_PlayPause.Text = "Pause (F5)";
            }
        }

        private void ts_btn_MemFlag_Click(object sender, EventArgs e)
        {
            if (interpreter != null)
                interpreter.State.MemFlag = !interpreter.State.MemFlag;
        }

        private void UpdateMemFlagButton(bool value)
        {
            ts_btn_MemFlag.Image = value ? Properties.Resources.box_checked : Properties.Resources.box_unchecked;
        }

        private void txb_StdIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;
            var txt = txb_StdIn.Text;
            txb_StdIn.Clear();

            if (txt.Length == 0)
                return;

            if (inputStream == null)
                return;

            inputStream.Write(Encoding.UTF8.GetBytes(txt));
            inputStream.Flush();
        }

        private void ts_ddbtn_Mode_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (interpreter == null || e.ClickedItem is not ToolStripMenuItem menuItem)
                return;

            interpreter.Mode = (RbMode)menuItem.Tag;
            menuItem.Checked = true;
            var items = ts_ddbtn_Mode.DropDownItems
                .Cast<ToolStripItem>()
                .Where(x => x is ToolStripMenuItem && x != e.ClickedItem);
            foreach (ToolStripMenuItem item in items)
            {
                item.Checked = false;
            }
        }

        private void ts_ddbtn_Direction_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (interpreter == null || e.ClickedItem is not ToolStripMenuItem menuItem)
                return;

            if (e.ClickedItem.Tag.Equals(0))
            {
                ts_Flow_Up.Checked = false;
                ts_Flow_Down.Checked = false;
                ts_Flow_Left.Checked = false;
                ts_Flow_Right.Checked = false;
                interpreter.Direction = RoundAbout.Runtime.FlowDirection.None;
                return;
            }

            bool state = !menuItem.Checked;
            menuItem.Checked = state;
            RoundAbout.Runtime.FlowDirection a, b;
            switch (menuItem.Tag)
            {
                case 1:
                    ts_Flow_Down.Checked = false;
                    a = RoundAbout.Runtime.FlowDirection.Up;
                    b = RoundAbout.Runtime.FlowDirection.Down;
                    if (state)
                    {
                        interpreter.Direction |= a;
                        interpreter.Direction &= ~b;
                    }
                    else
                    {
                        interpreter.Direction &= ~a;
                    }
                    break;

                case 2:
                    ts_Flow_Up.Checked = false;
                    a = RoundAbout.Runtime.FlowDirection.Down;
                    b = RoundAbout.Runtime.FlowDirection.Up;
                    if (state)
                    {
                        interpreter.Direction |= a;
                        interpreter.Direction &= ~b;
                    }
                    else
                    {
                        interpreter.Direction &= ~a;
                    }
                    break;

                case 4:
                    ts_Flow_Left.Checked = false;
                    a = RoundAbout.Runtime.FlowDirection.Left;
                    b = RoundAbout.Runtime.FlowDirection.Right;
                    if (state)
                    {
                        interpreter.Direction |= a;
                        interpreter.Direction &= ~b;
                    }
                    else
                    {
                        interpreter.Direction &= ~a;
                    }
                    break;

                case 8:
                    ts_Flow_Right.Checked = false;
                    a = RoundAbout.Runtime.FlowDirection.Right;
                    b = RoundAbout.Runtime.FlowDirection.Left;
                    if (state)
                    {
                        interpreter.Direction |= a;
                        interpreter.Direction &= ~b;
                    }
                    else
                    {
                        interpreter.Direction &= ~a;
                    }
                    break;
                default:
                    break;
            }
        }

        private void pnl_Draw_Resize(object sender, EventArgs e)
        {
            pnl_Draw.Refresh();
        }
    }
}