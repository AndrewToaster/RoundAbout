using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualRoundAbout
{
    public partial class ValuePrompt : Form
    {
        public BigInteger Value { get => _value; }
        private BigInteger _value;

        public ValuePrompt()
        {
            InitializeComponent();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (!BigInteger.TryParse(txb_Input.Text.Trim(), out _value))
            {
                MessageBox.Show(this, $"'{txb_Input.Text.Trim()}' is not a valid integer!",
                    "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txb_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_Ok_Click(btn_Ok, new EventArgs());
            }
        }
    }
}
