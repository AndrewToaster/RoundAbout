using System.Numerics;
using System.Text;
namespace RoundAbout;

public static class Utilities
{
    public static (int X, int Y) BoxWrap(int x, int y, int maxX, int maxY)
    {
        return (Modulo(x, maxX), Modulo(y, maxY));
    }

    public static int Wrap(int value, int max)
    {
        return Modulo(value, max);
    }

    public static T RandomElement<T>(params T[] elements)
    {
        return elements[Random.Shared.Next(elements.Length)];
    }

    public static int Modulo(int a, int b)
    {
        int x = a % b;
        while (x < 0)
            x += b;
        return x;
    }

    public static BigInteger BigModulo(BigInteger a, BigInteger b)
    {
        int sign = a.Sign * b.Sign;
        if (sign == -1)
        {
            return a - b * ((a / b) - 1);
        }
        else
        {
            return a - b * (a / b);
        }
    }

    public static BigInteger BigPow(BigInteger value, BigInteger power)
    {
        if (power.Sign == 0)
        {
            return BigInteger.One;
        }
        if (power.Sign < 0)
        {
            return BigInteger.Zero;
        }

        BigInteger result = value;
        while (power > 1)
        {
            result *= result;
            power--;
        }

        return result;
    }

    public static BigInteger BigRoot(BigInteger value, BigInteger root)
    {
        // Thanks random stranger on the internet
        if (root.Sign <= 0)
        {
            return BigInteger.Zero;
        }

        if (value.Sign < 0)
            throw new ArgumentException("Can't take root of a negative number", nameof(value));

        BigInteger n1 = root - 1;
        BigInteger n2 = root;
        BigInteger n3 = n1;
        BigInteger c = 1;
        BigInteger d = (n3 + value) / n2;
        BigInteger e = ((n3 * d) + (value / BigPow(d, n1))) / n2;
        while (c != d && c != e)
        {
            c = d;
            d = e;
            e = (n3 * e + value / BigPow(e, n1)) / n2;
        }
        if (d < e)
        {
            return d;
        }
        return e;
    }

    public static bool IsInt32(this BigInteger value)
    {
        return value <= int.MaxValue && value >= int.MinValue;
    }

    public static string GetString(BigInteger value)
    {
        return Encoding.UTF8.GetString(value.ToByteArray());
    }

    public static char GetSymbol(BigInteger value)
    {
        return Encoding.UTF8.GetString(value.ToByteArray())[0];
    }

    public static BigInteger GetNumber(string value)
    {
        return new BigInteger(Encoding.UTF8.GetBytes(value));
    }

    public static BigInteger GetNumber(char value)
    {
        return new BigInteger(Encoding.UTF8.GetBytes(value.ToString()));
    }

    public static void Resize2DArray<T>(ref T[,] original, int size1, int size2, T? filler = default)
    {
        if (size1 < 0)
            throw new ArgumentOutOfRangeException(nameof(size1), "Value must be non-negative");
        if (size2 < 0)
            throw new ArgumentOutOfRangeException(nameof(size2), "Value must be non-negative");

        var newArray = new T[size1, size2];
        var originalSize1 = original.GetLength(0);
        var originalSize2 = original.GetLength(1);

        for (int i = 0; i < size1; i++)
        {
            for (int j = 0; j < size2; j++)
            {
                if (i < originalSize1 && j < originalSize2)
                {
                    newArray[i, j] = original[i, j];
                }
                else
                {
                    newArray[i, j] = filler!;
                }
            }
        }
        original = newArray;
    }
}