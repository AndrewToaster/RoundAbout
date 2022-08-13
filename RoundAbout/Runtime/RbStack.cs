using System.Numerics;
namespace RoundAbout.Runtime;

public class RbStack
{
    public List<BigInteger> Collection { get; }
    public bool Any => Collection.Count > 0;
    public bool AtleastTwo => Collection.Count >= 2;

    public RbStack()
    {
        Collection = new List<BigInteger>();
    }

    public void Push(BigInteger value)
    {
        Collection.Insert(0, value);
        ItemAdded?.Invoke(value);
    }

    public BigInteger Pop()
    {
        var value = Collection[0];
        Collection.RemoveAt(0);
        ItemRemoved?.Invoke(value);
        return value;
    }

    public bool TryPop(out BigInteger value)
    {
        if (Collection.Count == 0)
        {
            value = BigInteger.Zero;
            return false;
        }

        value = Pop();
        return true;
    }

    public bool Swap()
    {
        if (Collection.Count < 2)
            return false;

        (Collection[1], Collection[0]) = (Collection[0], Collection[1]);
        ItemSwapped?.Invoke(Collection[1], Collection[0]);

        return true;
    }

    public void Dupe()
    {
        Push(Collection[0]);
    }

    public void Clear()
    {
        BigInteger[] items = Collection.ToArray();
        Collection.Clear();
        Cleared?.Invoke(items);
    }

    public event Action<BigInteger>? ItemAdded;
    public event Action<BigInteger>? ItemRemoved;
    public event Action<BigInteger, BigInteger>? ItemSwapped;
    public event Action<BigInteger[]>? Cleared;
}