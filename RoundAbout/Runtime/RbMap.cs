using System.Text;
namespace RoundAbout.Runtime;

public class RbMap
{
    public char[,] Content { get => _content; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    private char[,] _content;

    public RbMap(int width, int height, string content)
    {
        Width = width;
        Height = height;
        _content = new char[height, width];
        string[] lines = content.Split('\n');
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (y < lines.Length && x < lines[y].Length)
                {
                    Content[y, x] = lines[y][x];
                }
                else
                {
                    Content[y, x] = ' ';
                }
            }
        }
    }

    public RbMap(char[,] content)
    {
        _content = content;
        Width = content.GetLength(1);
        Height = content.GetLength(0);
    }

    public override string ToString()
    {
        StringBuilder sb = new((Width + 1) * Height);
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                sb.Append(Content[y, x]);
            }

            if (y < Height - 1)
                sb.Append('\n');
        }
        return sb.ToString();
    }

    public void Resize(int w, int h)
    {
        Utilities.Resize2DArray(ref _content, h, w, ' ');
        Width = w;
        Height = h;
        Resized?.Invoke(w, h);
    }

    public event Action<int, int>? Resized;
}