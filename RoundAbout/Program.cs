using RoundAbout;
using RoundAbout.Runtime;
using System;
using System.Diagnostics;
using System.Numerics;

const int R_SUCCESS = 0;
const int R_MALFORMED_DIMENSIONS = 1;
const int R_NO_FILE = 2;
const int R_FILE_NOT_FOUND = 3;

if (args.Length == 0)
{
    Console.WriteLine("No file provided");
    Environment.Exit(R_NO_FILE);
}

if (!File.Exists(args[0]))
{
    Console.WriteLine("No such file exists");
    Environment.Exit(R_FILE_NOT_FOUND);
}

var lines = File.ReadAllLines(args[0]);
if (lines.Length == 0)
    Environment.Exit(R_SUCCESS);

int w = 0;
int h = 0;
if (lines[0].StartsWith("//"))
{
    try
    {
        var x = lines[0][2..].Split(',').Select(x => int.Parse(x.Trim())).ToArray();
        (w, h) = (x[0], x[1]);
        lines = lines.Skip(1).ToArray();
    }
    catch (Exception e) when (e is FormatException or OverflowException)
    {
        Environment.Exit(R_MALFORMED_DIMENSIONS);
    }
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

var map = new RbMap(mapContent);
var state = new RbState(map, new(), new(), false, 0, 0, FlowDirection.Right, RbMode.Traversal);

if (args.Contains("--visual") || args.Contains("-v"))
{
    Stream output = File.Open("out.txt", FileMode.Create, FileAccess.Write, FileShare.Read);
    Stream input = File.Open("in.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
    var interpreter = new RbInterpreter(state, input, output);

    Console.Clear();
    Console.WriteLine(map);
    Console.CursorVisible = false;
    while (!state.Stopped)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.CursorLeft = state.X;
        Console.CursorTop = state.Y;
        Console.Write(state.CurrentSymbol);
        Console.ResetColor();

        Console.ReadKey(true);

        Console.CursorLeft = state.X;
        Console.CursorTop = state.Y;
        Console.Write(state.CurrentSymbol);

        interpreter.TryStep();
        output.Flush();
        input.Flush();
    }

    output.Dispose();
    input.Dispose();
    Console.CursorVisible = true;
}
else
{
    var interpreter = new RbInterpreter(state);
    while (!state.Stopped)
    {
        interpreter.TryStep();
    }
}
