using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace VisualRoundAbout
{
    public class HeapBoxItem
    {
        private readonly HeapBox _owner;
        private BigInteger _value;

        public BigInteger Index { get; }
        public BigInteger Value { get => _value; set { _value = value; _owner.RefreshItems(); } }
        public bool Selected => _owner.Index == Index;

        public HeapBoxItem(BigInteger value, BigInteger index, HeapBox owner)
        {
            _value = value;
            Index = index;
            _owner = owner;
        }

        public override string ToString()
        {
            if (Selected)
                return $"| {Value} @{Index:x8}";
            else
                return $"{Value} @{Index:x8}";
        }
    }
}
