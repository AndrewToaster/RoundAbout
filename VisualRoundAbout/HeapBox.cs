using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace VisualRoundAbout
{
    public class HeapBox : ListBox
    {
        public BigInteger Index { get => _index; set => SetIndex(value); }
        private BigInteger _index;

        protected override void Sort()
        {
            var items = Items.Cast<HeapBoxItem>().OrderBy(x => x.Selected).ThenBy(x => x.Index);
            Items.Clear();
            Items.AddRange(items.ToArray());
        }

        new public void RefreshItems()
        {
            base.RefreshItems();
        }

        private void SetIndex(BigInteger value)
        {
            var items = Items.Cast<HeapBoxItem>();
            var selected = items.FirstOrDefault(x => x.Selected);
            if (selected != null && selected.Value == 0)
            {
                Items.Remove(selected);
            }

            _index = value;
            var item = items.FirstOrDefault(x => x.Selected);

            if (item == null)
            {
                item = new HeapBoxItem(0, value, this);
                Items.Add(item);
            }

            RefreshItems();
        }

        public void RefreshIndex()
        {
            var items = Items.Cast<HeapBoxItem>();
            var item = items.FirstOrDefault(x => x.Selected);

            if (item == null)
            {
                item = new HeapBoxItem(0, Index, this);
                Items.Add(item);
            }
        }
    }
}
