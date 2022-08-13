using System.Numerics;
namespace RoundAbout.Runtime;

public class RbHeap
{
    public BigInteger Pointer { get => _pointer; set { _pointer = value; PointerChanged?.Invoke(value); } }
    public Dictionary<BigInteger, BigInteger> Cells { get; }

    private BigInteger _pointer;

    public RbHeap()
    {
        Cells = new();
    }

    public void SetCell(BigInteger index, BigInteger value)
    {
        if (value == 0 && Cells.ContainsKey(index))
        {
            Cells.Remove(index);
        }
        else
        {
            Cells[index] = value;
        }
        CellChanged?.Invoke(value, index);
    }

    public BigInteger GetCell(BigInteger index)
    {
        if (!Cells.ContainsKey(index))
            return BigInteger.Zero;

        return Cells[index];
    }

    public void Clear()
    {
        var items = Cells.ToArray();
        Cells.Clear();
        Cleared?.Invoke(items);
    }

    public void SetCurrentCell(BigInteger value) => SetCell(Pointer, value);
    public BigInteger GetCurrentCell() => GetCell(Pointer);

    public event Action<BigInteger>? PointerChanged;
    public event Action<BigInteger, BigInteger>? CellChanged;
    public event Action<KeyValuePair<BigInteger, BigInteger>[]>? Cleared;
}
