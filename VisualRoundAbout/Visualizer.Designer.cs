namespace VisualRoundAbout
{
    partial class Visualizer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visualizer));
            this.tblpnl_Grid = new System.Windows.Forms.TableLayoutPanel();
            this.pnl_Draw = new System.Windows.Forms.Panel();
            this.lstv_Stack = new System.Windows.Forms.ListView();
            this.header_PadLeft = new System.Windows.Forms.ColumnHeader();
            this.header_Main = new System.Windows.Forms.ColumnHeader();
            this.header_PadRight = new System.Windows.Forms.ColumnHeader();
            this.btn_StackPush = new System.Windows.Forms.Button();
            this.btn_StackPop = new System.Windows.Forms.Button();
            this.lstb_Heap = new VisualRoundAbout.HeapBox();
            this.tbpnl_IO = new System.Windows.Forms.TableLayoutPanel();
            this.txb_StdOut = new System.Windows.Forms.TextBox();
            this.txb_StdIn = new System.Windows.Forms.TextBox();
            this.ts_Main = new System.Windows.Forms.ToolStrip();
            this.ts_btn_Open = new System.Windows.Forms.ToolStripButton();
            this.ts_sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_btn_Next = new System.Windows.Forms.ToolStripButton();
            this.ts_btn_PlayPause = new System.Windows.Forms.ToolStripButton();
            this.ts_sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_lbl_Speed = new System.Windows.Forms.ToolStripLabel();
            this.ts_txb_Speed = new System.Windows.Forms.ToolStripTextBox();
            this.ts_sep3 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_btn_MemFlag = new System.Windows.Forms.ToolStripButton();
            this.ts_ddbtn_Mode = new System.Windows.Forms.ToolStripDropDownButton();
            this.ts_Mode_Traversal = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Mode_FlowTesting = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Mode_Testing = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Mode_Operation = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Mode_Stack = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Mode_Heap = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Mode_IO = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_sep4 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_Mode_Stopped = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_ddbtn_Direction = new System.Windows.Forms.ToolStripDropDownButton();
            this.ts_Flow_Up = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Flow_Down = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Flow_Left = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Flow_Right = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_sep5 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_Flow_None = new System.Windows.Forms.ToolStripMenuItem();
            this.t_Update = new System.Windows.Forms.Timer(this.components);
            this.pnl_Toolstrip = new System.Windows.Forms.Panel();
            this.fod_Code = new System.Windows.Forms.OpenFileDialog();
            this.tblpnl_Grid.SuspendLayout();
            this.tbpnl_IO.SuspendLayout();
            this.ts_Main.SuspendLayout();
            this.pnl_Toolstrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblpnl_Grid
            // 
            this.tblpnl_Grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblpnl_Grid.ColumnCount = 4;
            this.tblpnl_Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblpnl_Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblpnl_Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblpnl_Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblpnl_Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblpnl_Grid.Controls.Add(this.pnl_Draw, 0, 0);
            this.tblpnl_Grid.Controls.Add(this.lstv_Stack, 2, 0);
            this.tblpnl_Grid.Controls.Add(this.btn_StackPush, 2, 3);
            this.tblpnl_Grid.Controls.Add(this.btn_StackPop, 3, 3);
            this.tblpnl_Grid.Controls.Add(this.lstb_Heap, 0, 2);
            this.tblpnl_Grid.Controls.Add(this.tbpnl_IO, 1, 2);
            this.tblpnl_Grid.Location = new System.Drawing.Point(0, 31);
            this.tblpnl_Grid.Name = "tblpnl_Grid";
            this.tblpnl_Grid.RowCount = 4;
            this.tblpnl_Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblpnl_Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblpnl_Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblpnl_Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblpnl_Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblpnl_Grid.Size = new System.Drawing.Size(1085, 670);
            this.tblpnl_Grid.TabIndex = 0;
            // 
            // pnl_Draw
            // 
            this.pnl_Draw.BackColor = System.Drawing.SystemColors.Control;
            this.tblpnl_Grid.SetColumnSpan(this.pnl_Draw, 2);
            this.pnl_Draw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Draw.Location = new System.Drawing.Point(3, 3);
            this.pnl_Draw.Name = "pnl_Draw";
            this.tblpnl_Grid.SetRowSpan(this.pnl_Draw, 2);
            this.pnl_Draw.Size = new System.Drawing.Size(862, 530);
            this.pnl_Draw.TabIndex = 0;
            this.pnl_Draw.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Draw_Paint);
            this.pnl_Draw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_Draw_MouseDown);
            this.pnl_Draw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_Draw_MouseMove);
            this.pnl_Draw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_Draw_MouseUp);
            this.pnl_Draw.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pnl_Draw_MouseWheel);
            this.pnl_Draw.Resize += new System.EventHandler(this.pnl_Draw_Resize);
            // 
            // lstv_Stack
            // 
            this.lstv_Stack.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.header_PadLeft,
            this.header_Main,
            this.header_PadRight});
            this.tblpnl_Grid.SetColumnSpan(this.lstv_Stack, 2);
            this.lstv_Stack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstv_Stack.Enabled = false;
            this.lstv_Stack.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstv_Stack.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstv_Stack.Location = new System.Drawing.Point(871, 3);
            this.lstv_Stack.Name = "lstv_Stack";
            this.tblpnl_Grid.SetRowSpan(this.lstv_Stack, 3);
            this.lstv_Stack.Size = new System.Drawing.Size(211, 597);
            this.lstv_Stack.TabIndex = 1;
            this.lstv_Stack.UseCompatibleStateImageBehavior = false;
            this.lstv_Stack.View = System.Windows.Forms.View.Details;
            this.lstv_Stack.DoubleClick += new System.EventHandler(this.lstv_Stack_DoubleClick);
            this.lstv_Stack.Resize += new System.EventHandler(this.lstv_Stack_Resize);
            // 
            // header_PadLeft
            // 
            this.header_PadLeft.DisplayIndex = 1;
            this.header_PadLeft.Text = "";
            this.header_PadLeft.Width = 1;
            // 
            // header_Main
            // 
            this.header_Main.DisplayIndex = 0;
            this.header_Main.Text = "";
            this.header_Main.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.header_Main.Width = 1;
            // 
            // header_PadRight
            // 
            this.header_PadRight.Text = "";
            this.header_PadRight.Width = 1;
            // 
            // btn_StackPush
            // 
            this.btn_StackPush.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_StackPush.Enabled = false;
            this.btn_StackPush.Location = new System.Drawing.Point(871, 606);
            this.btn_StackPush.Name = "btn_StackPush";
            this.btn_StackPush.Size = new System.Drawing.Size(102, 61);
            this.btn_StackPush.TabIndex = 2;
            this.btn_StackPush.Text = "Push";
            this.btn_StackPush.UseVisualStyleBackColor = true;
            this.btn_StackPush.Click += new System.EventHandler(this.btn_StackPush_Click);
            // 
            // btn_StackPop
            // 
            this.btn_StackPop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_StackPop.Enabled = false;
            this.btn_StackPop.Location = new System.Drawing.Point(979, 606);
            this.btn_StackPop.Name = "btn_StackPop";
            this.btn_StackPop.Size = new System.Drawing.Size(103, 61);
            this.btn_StackPop.TabIndex = 3;
            this.btn_StackPop.Text = "Pop";
            this.btn_StackPop.UseVisualStyleBackColor = true;
            this.btn_StackPop.Click += new System.EventHandler(this.btn_StackPop_Click);
            // 
            // lstb_Heap
            // 
            this.lstb_Heap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstb_Heap.Enabled = false;
            this.lstb_Heap.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstb_Heap.FormattingEnabled = true;
            this.lstb_Heap.Index = ((System.Numerics.BigInteger)(resources.GetObject("lstb_Heap.Index")));
            this.lstb_Heap.IntegralHeight = false;
            this.lstb_Heap.ItemHeight = 25;
            this.lstb_Heap.Location = new System.Drawing.Point(3, 539);
            this.lstb_Heap.Name = "lstb_Heap";
            this.tblpnl_Grid.SetRowSpan(this.lstb_Heap, 2);
            this.lstb_Heap.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstb_Heap.Size = new System.Drawing.Size(428, 128);
            this.lstb_Heap.Sorted = true;
            this.lstb_Heap.TabIndex = 4;
            // 
            // tbpnl_IO
            // 
            this.tbpnl_IO.ColumnCount = 1;
            this.tbpnl_IO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbpnl_IO.Controls.Add(this.txb_StdOut, 0, 0);
            this.tbpnl_IO.Controls.Add(this.txb_StdIn, 0, 1);
            this.tbpnl_IO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbpnl_IO.Location = new System.Drawing.Point(434, 536);
            this.tbpnl_IO.Margin = new System.Windows.Forms.Padding(0);
            this.tbpnl_IO.Name = "tbpnl_IO";
            this.tbpnl_IO.RowCount = 2;
            this.tblpnl_Grid.SetRowSpan(this.tbpnl_IO, 2);
            this.tbpnl_IO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbpnl_IO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tbpnl_IO.Size = new System.Drawing.Size(434, 134);
            this.tbpnl_IO.TabIndex = 7;
            // 
            // txb_StdOut
            // 
            this.txb_StdOut.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txb_StdOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_StdOut.Enabled = false;
            this.txb_StdOut.Location = new System.Drawing.Point(3, 3);
            this.txb_StdOut.MaxLength = 2147483647;
            this.txb_StdOut.Multiline = true;
            this.txb_StdOut.Name = "txb_StdOut";
            this.txb_StdOut.ReadOnly = true;
            this.txb_StdOut.Size = new System.Drawing.Size(428, 100);
            this.txb_StdOut.TabIndex = 7;
            this.txb_StdOut.WordWrap = false;
            // 
            // txb_StdIn
            // 
            this.txb_StdIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_StdIn.Enabled = false;
            this.txb_StdIn.Location = new System.Drawing.Point(3, 109);
            this.txb_StdIn.Name = "txb_StdIn";
            this.txb_StdIn.Size = new System.Drawing.Size(428, 23);
            this.txb_StdIn.TabIndex = 8;
            this.txb_StdIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_StdIn_KeyDown);
            // 
            // ts_Main
            // 
            this.ts_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ts_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_btn_Open,
            this.ts_sep1,
            this.ts_btn_Next,
            this.ts_btn_PlayPause,
            this.ts_sep2,
            this.ts_lbl_Speed,
            this.ts_txb_Speed,
            this.ts_sep3,
            this.ts_btn_MemFlag,
            this.ts_ddbtn_Mode,
            this.ts_ddbtn_Direction});
            this.ts_Main.Location = new System.Drawing.Point(0, 0);
            this.ts_Main.Name = "ts_Main";
            this.ts_Main.Size = new System.Drawing.Size(1085, 25);
            this.ts_Main.TabIndex = 0;
            this.ts_Main.Text = "toolStrip1";
            // 
            // ts_btn_Open
            // 
            this.ts_btn_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_btn_Open.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_Open.Image")));
            this.ts_btn_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_btn_Open.Name = "ts_btn_Open";
            this.ts_btn_Open.Size = new System.Drawing.Size(40, 22);
            this.ts_btn_Open.Text = "Open";
            this.ts_btn_Open.Click += new System.EventHandler(this.ts_btn_Open_Click);
            // 
            // ts_sep1
            // 
            this.ts_sep1.Name = "ts_sep1";
            this.ts_sep1.Size = new System.Drawing.Size(6, 25);
            // 
            // ts_btn_Next
            // 
            this.ts_btn_Next.Enabled = false;
            this.ts_btn_Next.Image = global::VisualRoundAbout.Properties.Resources.next;
            this.ts_btn_Next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_btn_Next.Name = "ts_btn_Next";
            this.ts_btn_Next.Size = new System.Drawing.Size(75, 22);
            this.ts_btn_Next.Text = "Next (F7)";
            this.ts_btn_Next.ToolTipText = "Moves the program one step forward";
            this.ts_btn_Next.Click += new System.EventHandler(this.ts_btn_Next_Click);
            // 
            // ts_btn_PlayPause
            // 
            this.ts_btn_PlayPause.Enabled = false;
            this.ts_btn_PlayPause.Image = global::VisualRoundAbout.Properties.Resources.play_button;
            this.ts_btn_PlayPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_btn_PlayPause.Name = "ts_btn_PlayPause";
            this.ts_btn_PlayPause.Size = new System.Drawing.Size(72, 22);
            this.ts_btn_PlayPause.Text = "Play (F5)";
            this.ts_btn_PlayPause.Click += new System.EventHandler(this.ts_btn_PlayPause_Click);
            // 
            // ts_sep2
            // 
            this.ts_sep2.Name = "ts_sep2";
            this.ts_sep2.Size = new System.Drawing.Size(6, 25);
            // 
            // ts_lbl_Speed
            // 
            this.ts_lbl_Speed.Enabled = false;
            this.ts_lbl_Speed.Name = "ts_lbl_Speed";
            this.ts_lbl_Speed.Size = new System.Drawing.Size(66, 22);
            this.ts_lbl_Speed.Text = "Speed (ms)";
            // 
            // ts_txb_Speed
            // 
            this.ts_txb_Speed.BackColor = System.Drawing.Color.Gainsboro;
            this.ts_txb_Speed.Enabled = false;
            this.ts_txb_Speed.Name = "ts_txb_Speed";
            this.ts_txb_Speed.Size = new System.Drawing.Size(100, 25);
            this.ts_txb_Speed.Text = "25";
            this.ts_txb_Speed.TextChanged += new System.EventHandler(this.ts_txb_Speed_TextChanged);
            // 
            // ts_sep3
            // 
            this.ts_sep3.Name = "ts_sep3";
            this.ts_sep3.Size = new System.Drawing.Size(6, 25);
            // 
            // ts_btn_MemFlag
            // 
            this.ts_btn_MemFlag.Enabled = false;
            this.ts_btn_MemFlag.Image = global::VisualRoundAbout.Properties.Resources.box_unchecked;
            this.ts_btn_MemFlag.Name = "ts_btn_MemFlag";
            this.ts_btn_MemFlag.Size = new System.Drawing.Size(97, 22);
            this.ts_btn_MemFlag.Text = "Memory Flag";
            this.ts_btn_MemFlag.Click += new System.EventHandler(this.ts_btn_MemFlag_Click);
            // 
            // ts_ddbtn_Mode
            // 
            this.ts_ddbtn_Mode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_ddbtn_Mode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_Mode_Traversal,
            this.ts_Mode_FlowTesting,
            this.ts_Mode_Testing,
            this.ts_Mode_Operation,
            this.ts_Mode_Stack,
            this.ts_Mode_Heap,
            this.ts_Mode_IO,
            this.ts_sep4,
            this.ts_Mode_Stopped});
            this.ts_ddbtn_Mode.Enabled = false;
            this.ts_ddbtn_Mode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_ddbtn_Mode.Name = "ts_ddbtn_Mode";
            this.ts_ddbtn_Mode.Size = new System.Drawing.Size(51, 22);
            this.ts_ddbtn_Mode.Text = "Mode";
            this.ts_ddbtn_Mode.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ts_ddbtn_Mode_DropDownItemClicked);
            // 
            // ts_Mode_Traversal
            // 
            this.ts_Mode_Traversal.Name = "ts_Mode_Traversal";
            this.ts_Mode_Traversal.Size = new System.Drawing.Size(139, 22);
            this.ts_Mode_Traversal.Tag = 0;
            this.ts_Mode_Traversal.Text = "Traversal";
            // 
            // ts_Mode_FlowTesting
            // 
            this.ts_Mode_FlowTesting.Name = "ts_Mode_FlowTesting";
            this.ts_Mode_FlowTesting.Size = new System.Drawing.Size(139, 22);
            this.ts_Mode_FlowTesting.Tag = 1;
            this.ts_Mode_FlowTesting.Text = "Flow Testing";
            // 
            // ts_Mode_Testing
            // 
            this.ts_Mode_Testing.Name = "ts_Mode_Testing";
            this.ts_Mode_Testing.Size = new System.Drawing.Size(139, 22);
            this.ts_Mode_Testing.Tag = 2;
            this.ts_Mode_Testing.Text = "Testing";
            // 
            // ts_Mode_Operation
            // 
            this.ts_Mode_Operation.Name = "ts_Mode_Operation";
            this.ts_Mode_Operation.Size = new System.Drawing.Size(139, 22);
            this.ts_Mode_Operation.Tag = 3;
            this.ts_Mode_Operation.Text = "Operation";
            // 
            // ts_Mode_Stack
            // 
            this.ts_Mode_Stack.Name = "ts_Mode_Stack";
            this.ts_Mode_Stack.Size = new System.Drawing.Size(139, 22);
            this.ts_Mode_Stack.Tag = 4;
            this.ts_Mode_Stack.Text = "Stack";
            // 
            // ts_Mode_Heap
            // 
            this.ts_Mode_Heap.Name = "ts_Mode_Heap";
            this.ts_Mode_Heap.Size = new System.Drawing.Size(139, 22);
            this.ts_Mode_Heap.Tag = 5;
            this.ts_Mode_Heap.Text = "Heap";
            // 
            // ts_Mode_IO
            // 
            this.ts_Mode_IO.Name = "ts_Mode_IO";
            this.ts_Mode_IO.Size = new System.Drawing.Size(139, 22);
            this.ts_Mode_IO.Tag = 6;
            this.ts_Mode_IO.Text = "IO";
            // 
            // ts_sep4
            // 
            this.ts_sep4.Name = "ts_sep4";
            this.ts_sep4.Size = new System.Drawing.Size(136, 6);
            // 
            // ts_Mode_Stopped
            // 
            this.ts_Mode_Stopped.Name = "ts_Mode_Stopped";
            this.ts_Mode_Stopped.Size = new System.Drawing.Size(139, 22);
            this.ts_Mode_Stopped.Tag = 7;
            this.ts_Mode_Stopped.Text = "Stopped";
            // 
            // ts_ddbtn_Direction
            // 
            this.ts_ddbtn_Direction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_ddbtn_Direction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_Flow_Up,
            this.ts_Flow_Down,
            this.ts_Flow_Left,
            this.ts_Flow_Right,
            this.ts_sep5,
            this.ts_Flow_None});
            this.ts_ddbtn_Direction.Enabled = false;
            this.ts_ddbtn_Direction.Image = ((System.Drawing.Image)(resources.GetObject("ts_ddbtn_Direction.Image")));
            this.ts_ddbtn_Direction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_ddbtn_Direction.Name = "ts_ddbtn_Direction";
            this.ts_ddbtn_Direction.Size = new System.Drawing.Size(96, 22);
            this.ts_ddbtn_Direction.Text = "Flow Direction";
            this.ts_ddbtn_Direction.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ts_ddbtn_Direction_DropDownItemClicked);
            // 
            // ts_Flow_Up
            // 
            this.ts_Flow_Up.Name = "ts_Flow_Up";
            this.ts_Flow_Up.Size = new System.Drawing.Size(105, 22);
            this.ts_Flow_Up.Tag = 1;
            this.ts_Flow_Up.Text = "Up";
            // 
            // ts_Flow_Down
            // 
            this.ts_Flow_Down.Name = "ts_Flow_Down";
            this.ts_Flow_Down.Size = new System.Drawing.Size(105, 22);
            this.ts_Flow_Down.Tag = 2;
            this.ts_Flow_Down.Text = "Down";
            // 
            // ts_Flow_Left
            // 
            this.ts_Flow_Left.Name = "ts_Flow_Left";
            this.ts_Flow_Left.Size = new System.Drawing.Size(105, 22);
            this.ts_Flow_Left.Tag = 4;
            this.ts_Flow_Left.Text = "Left";
            // 
            // ts_Flow_Right
            // 
            this.ts_Flow_Right.Name = "ts_Flow_Right";
            this.ts_Flow_Right.Size = new System.Drawing.Size(105, 22);
            this.ts_Flow_Right.Tag = 8;
            this.ts_Flow_Right.Text = "Right";
            // 
            // ts_sep5
            // 
            this.ts_sep5.Name = "ts_sep5";
            this.ts_sep5.Size = new System.Drawing.Size(102, 6);
            // 
            // ts_Flow_None
            // 
            this.ts_Flow_None.Name = "ts_Flow_None";
            this.ts_Flow_None.Size = new System.Drawing.Size(105, 22);
            this.ts_Flow_None.Tag = 0;
            this.ts_Flow_None.Text = "None";
            // 
            // t_Update
            // 
            this.t_Update.Interval = 25;
            this.t_Update.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // pnl_Toolstrip
            // 
            this.pnl_Toolstrip.Controls.Add(this.ts_Main);
            this.pnl_Toolstrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Toolstrip.Location = new System.Drawing.Point(0, 0);
            this.pnl_Toolstrip.Name = "pnl_Toolstrip";
            this.pnl_Toolstrip.Size = new System.Drawing.Size(1085, 25);
            this.pnl_Toolstrip.TabIndex = 1;
            // 
            // fod_Code
            // 
            this.fod_Code.RestoreDirectory = true;
            // 
            // Visualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 701);
            this.Controls.Add(this.pnl_Toolstrip);
            this.Controls.Add(this.tblpnl_Grid);
            this.Name = "Visualizer";
            this.Text = "Visually Roundabout";
            this.Load += new System.EventHandler(this.Visualizer_Load);
            this.tblpnl_Grid.ResumeLayout(false);
            this.tbpnl_IO.ResumeLayout(false);
            this.tbpnl_IO.PerformLayout();
            this.ts_Main.ResumeLayout(false);
            this.ts_Main.PerformLayout();
            this.pnl_Toolstrip.ResumeLayout(false);
            this.pnl_Toolstrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tblpnl_Grid;
        private Panel pnl_Draw;
        private ListView lstv_Stack;
        private ColumnHeader header_Main;
        private ColumnHeader header_PadLeft;
        private ColumnHeader header_PadRight;
        private System.Windows.Forms.Timer t_Update;
        private ToolStrip ts_Main;
        private ToolStripButton ts_btn_Open;
        private ToolStripSeparator ts_sep1;
        private ToolStripButton ts_btn_Next;
        private Panel pnl_Toolstrip;
        private OpenFileDialog fod_Code;
        private HeapBox lstb_Heap;
        private ToolStripButton ts_btn_PlayPause;
        private ToolStripSeparator ts_sep2;
        private ToolStripLabel ts_lbl_Speed;
        private ToolStripTextBox ts_txb_Speed;
        private ToolStripSeparator ts_sep3;
        private ToolStripButton ts_btn_MemFlag;
        private Button btn_StackPush;
        private Button btn_StackPop;
        private TableLayoutPanel tbpnl_IO;
        private TextBox txb_StdOut;
        private TextBox txb_StdIn;
        private ToolStripDropDownButton ts_ddbtn_Mode;
        private ToolStripMenuItem ts_Mode_Traversal;
        private ToolStripMenuItem ts_Mode_FlowTesting;
        private ToolStripMenuItem ts_Mode_Testing;
        private ToolStripMenuItem ts_Mode_Operation;
        private ToolStripMenuItem ts_Mode_Stack;
        private ToolStripMenuItem ts_Mode_Heap;
        private ToolStripMenuItem ts_Mode_IO;
        private ToolStripSeparator ts_sep4;
        private ToolStripMenuItem ts_Mode_Stopped;
        private ToolStripDropDownButton ts_ddbtn_Direction;
        private ToolStripMenuItem ts_Flow_Up;
        private ToolStripMenuItem ts_Flow_Down;
        private ToolStripMenuItem ts_Flow_Left;
        private ToolStripMenuItem ts_Flow_Right;
        private ToolStripSeparator ts_sep5;
        private ToolStripMenuItem ts_Flow_None;
    }
}