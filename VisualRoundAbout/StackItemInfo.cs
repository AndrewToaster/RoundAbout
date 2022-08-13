using RoundAbout.Runtime;
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
    public partial class StackItemInfo : Form
    {
        private readonly RbStack stack;
        private int index;

        public StackItemInfo(RbStack stack, int index)
        {
            InitializeComponent();
            this.stack = stack;
            this.index = index;

            // Track stack item index change
            this.stack.ItemAdded += Stack_ItemAdded;
            this.stack.ItemRemoved += Stack_ItemRemoved;
            this.stack.ItemSwapped += Stack_ItemSwapped;
            this.stack.Cleared += Stack_Cleared;
        }

        private void Stack_Cleared(BigInteger[] arg)
        {
            index = -1;
        }

        private void Stack_ItemSwapped(BigInteger arg1, BigInteger arg2)
        {
            if (index == 0)
                index = 1;
        }

        private void Stack_ItemRemoved(BigInteger arg)
        {
            if (index >= 0)
                index--;
        }

        private void Stack_ItemAdded(BigInteger arg)
        {
            if (index >= 0)
                index++;
        }

        private void StackItemInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
