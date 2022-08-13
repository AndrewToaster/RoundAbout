using System.Numerics;
using System.Text;
namespace RoundAbout.Runtime;

public class RbInterpreter
{
    public FlowDirection Direction { get => State.Direction; set => State.Direction = value; }
    public bool MemFlag { get => State.MemFlag; set => State.MemFlag = value; }
    public RbMode Mode { get => State.Mode; set => State.Mode = value; }
    public char CurrentSymbol { get => State.CurrentSymbol; set => State.CurrentSymbol = value; }
    public bool Stopped { get => State.Stopped; set => State.Stopped = value; }
    public int X { get => State.X; set => State.X = value; }
    public int Y { get => State.Y; set => State.Y = value; }

    public RbStack Stack => State.Stack;
    public RbHeap Heap => State.Heap;
    public RbMap Map => State.Map;
    public bool RespectFlow => State.RespectFlow;

    public Stream StdIn { get; private set; }
    public Stream StdOut { get; private set; }

    private StreamReader _reader;

    public RbState State { get; }

    public RbInterpreter(RbState state, Stream? stdin = null, Stream? stdout = null)
    {
        State = state;
        StdIn = stdin ?? Console.OpenStandardInput();
        StdOut = stdout ?? Console.OpenStandardOutput();
        _reader = new StreamReader(StdIn, Encoding.UTF8);
    }

    public void SetStdIn(Stream stream)
    {
        StdIn = stream;
        _reader = new StreamReader(stream);
    }

    public void SetStdOut(Stream stream)
    {
        StdOut = stream;
    }

    public bool TryStep()
    {
        if (Stopped)
            return false;

        bool step = true;
        switch (CurrentSymbol)
        {
            #region Mode Operators
            case ';':
                Mode = RbMode.Traversal;
                break;

            case '~':
                Stopped = true;
                Direction = FlowDirection.None;
                return false;

            case '@' when RespectFlow:
                Mode = RbMode.FlowTesting;
                break;

            case '?' when RespectFlow:
                Mode = RbMode.Testing;
                break;

            case '=' when RespectFlow:
                Mode = RbMode.Stack;
                break;

            case '[' when RespectFlow:
                Mode = RbMode.Heap;
                break;

            case '$' when RespectFlow:
                Mode = RbMode.IO;
                break;

            case '%' when RespectFlow:
                Mode = RbMode.Operation;
                break;

            case '#' when RespectFlow:
                Mode = RbMode.Map;
                break;
            #endregion Mode Operators

            #region Flow Operators
            case '>' when RespectFlow:
                Direction = FlowDirection.Right;
                break;

            case '<' when RespectFlow:
                Direction = FlowDirection.Left;
                break;

            case 'v' when RespectFlow:
                Direction = FlowDirection.Down;
                break;

            case '^' when RespectFlow:
                Direction = FlowDirection.Up;
                break;

            case '/' when RespectFlow:
                Direction = Direction switch
                {
                    FlowDirection.Left => FlowDirection.LeftDown,
                    FlowDirection.Right => FlowDirection.RightUp,
                    FlowDirection.Up => FlowDirection.RightUp,
                    FlowDirection.Down => FlowDirection.LeftDown,
                    FlowDirection.LeftUp => FlowDirection.RightDown,
                    FlowDirection.RightDown => FlowDirection.LeftUp,
                    _ => FlowDirection.None,
                };
                break;

            case '\\' when RespectFlow:
                Direction = Direction switch
                {
                    FlowDirection.Left => FlowDirection.LeftUp,
                    FlowDirection.Right => FlowDirection.RightDown,
                    FlowDirection.Up => FlowDirection.LeftUp,
                    FlowDirection.Down => FlowDirection.RightDown,
                    FlowDirection.RightUp => FlowDirection.LeftDown,
                    FlowDirection.LeftDown => FlowDirection.RightUp,
                    _ => Direction,
                };
                break;

            case '|' when RespectFlow:
                Direction = Direction switch
                {
                    FlowDirection.Left => FlowDirection.Right,
                    FlowDirection.Right => FlowDirection.Left,
                    FlowDirection.LeftDown => FlowDirection.Down,
                    FlowDirection.LeftUp => FlowDirection.Up,
                    FlowDirection.RightDown => FlowDirection.Down,
                    FlowDirection.RightUp => FlowDirection.Up,
                    _ => Direction
                };
                break;

            case '-' when RespectFlow:
                Direction = Direction switch
                {
                    FlowDirection.Up => FlowDirection.Down,
                    FlowDirection.Down => FlowDirection.Up,
                    FlowDirection.LeftDown => FlowDirection.Left,
                    FlowDirection.LeftUp => FlowDirection.Left,
                    FlowDirection.RightDown => FlowDirection.Right,
                    FlowDirection.RightUp => FlowDirection.Right,
                    _ => Direction
                };
                break;

            case '+' when RespectFlow:
                Direction = Utilities.RandomElement(new FlowDirection[]
                {
                        FlowDirection.Up,
                        FlowDirection.Down,
                        FlowDirection.Left,
                        FlowDirection.Right
                });
                break;

            case 'x' when RespectFlow:
                Direction = Utilities.RandomElement(new FlowDirection[]
                {
                        FlowDirection.LeftUp,
                        FlowDirection.LeftDown,
                        FlowDirection.RightUp,
                        FlowDirection.RightDown
                });
                break;

            case '*' when RespectFlow:
                Direction = Utilities.RandomElement(new FlowDirection[]
                {
                        FlowDirection.Up,
                        FlowDirection.Down,
                        FlowDirection.Left,
                        FlowDirection.Right,
                        FlowDirection.LeftUp,
                        FlowDirection.LeftDown,
                        FlowDirection.RightUp,
                        FlowDirection.RightDown
                });
                break;
            #endregion Flow Operators

            #region Testing Operators
            case '>' when Mode == RbMode.Testing && Stack.AtleastTwo:
                MemFlag = Stack.Collection[1] > Stack.Collection[0];
                break;

            case '<' when Mode == RbMode.Testing && Stack.AtleastTwo:
                MemFlag = Stack.Collection[1] < Stack.Collection[0];
                break;

            case '=' when Mode == RbMode.Testing && Stack.AtleastTwo:
                MemFlag = Stack.Collection[1] == Stack.Collection[0];
                break;

            case '!' when Mode == RbMode.Testing && Stack.AtleastTwo:
                MemFlag = Stack.Collection[1] != Stack.Collection[0];
                break;
            #endregion Testing Operators

            #region Operation Operators
            case '+' when Mode == RbMode.Operation && Stack.AtleastTwo:
                BigInteger op_right = Stack.Pop();
                BigInteger op_left = Stack.Pop();
                Stack.Push(BigInteger.Add(op_left, op_right));
                break;

            case '-' when Mode == RbMode.Operation && Stack.AtleastTwo:
                op_right = Stack.Pop();
                op_left = Stack.Pop();
                Stack.Push(BigInteger.Subtract(op_left, op_right));
                break;

            case '*' when Mode == RbMode.Operation && Stack.AtleastTwo:
                op_right = Stack.Pop();
                op_left = Stack.Pop();
                Stack.Push(BigInteger.Multiply(op_left, op_right));
                break;

            case '/' when Mode == RbMode.Operation && Stack.AtleastTwo:
                op_right = Stack.Pop();
                op_left = Stack.Pop();
                Stack.Push(BigInteger.Divide(op_left, op_right));
                break;

            case '^' when Mode == RbMode.Operation && Stack.AtleastTwo:
                op_right = Stack.Pop();
                op_left = Stack.Pop();
                Stack.Push(Utilities.BigPow(op_left, op_right));
                break;

            case '\\' when Mode == RbMode.Operation && Stack.AtleastTwo:
                op_right = Stack.Pop();
                op_left = Stack.Pop();
                Stack.Push(Utilities.BigRoot(op_left, op_right));
                break;

            case '%' when Mode == RbMode.Operation && Stack.AtleastTwo:
                op_right = Stack.Pop();
                op_left = Stack.Pop();
                Stack.Push(Utilities.BigModulo(op_left, op_right));
                break;
            #endregion IO Operators

            #region Stack Operators
            case '+' when Mode == RbMode.Stack:
                step = false;
                StepCursor();
                if (TryReadDigits(out BigInteger num))
                    Stack.Push(num);
                else
                    throw new MalformedNumberException();
                break;

            case '-' when Mode == RbMode.Stack && Stack.Any:
                Stack.Pop();
                break;

            case '*' when Mode == RbMode.Stack:
                Stack.Swap();
                break;

            case '!' when Mode == RbMode.Stack:
                MemFlag = !MemFlag;
                break;

            case '0' when Mode == RbMode.Stack:
                MemFlag = false;
                break;

            case '1' when Mode == RbMode.Stack:
                MemFlag = true;
                break;

            case '>' when Mode == RbMode.Stack && Stack.Any:
                Heap.SetCurrentCell(Stack.Pop());
                break;

            case '<' when Mode == RbMode.Stack:
                Stack.Push(Heap.GetCurrentCell());
                break;

            case '?' when Mode == RbMode.Stack:
                MemFlag = Stack.Any;
                break;

            case ':' when Mode == RbMode.Stack && Stack.Any:
                Stack.Dupe();
                break;

            case '&' when Mode == RbMode.Stack:
                Stack.Clear();
                break;
            #endregion Stack Operators

            #region Heap Operators
            case '>' when Mode == RbMode.Heap:
                Heap.Pointer++;
                break;

            case '<' when Mode == RbMode.Heap:
                Heap.Pointer--;
                break;

            case '+' when Mode == RbMode.Heap:
                Heap.SetCurrentCell(Heap.GetCurrentCell() + 1);
                break;

            case '-' when Mode == RbMode.Heap:
                Heap.SetCurrentCell(Heap.GetCurrentCell() - 1);
                break;

            case '0' when Mode == RbMode.Heap:
                Heap.SetCurrentCell(0);
                break;

            case '*' when Mode == RbMode.Heap:
                Heap.Pointer = 0;
                break;

            case '#' when Mode == RbMode.Heap && Stack.Any:
                Heap.Pointer = Stack.Pop();
                break;

            case '&' when Mode == RbMode.Heap:
                Heap.Clear();
                break;
            #endregion Heap Operators

            #region IO Operators
            case '+' when Mode == RbMode.IO && Stack.Any:
                StdOut.Write(Stack.Pop().ToByteArray());
                break;

            case '-' when Mode == RbMode.IO:
                var letter = _reader.Read();
                Stack.Push(new BigInteger(letter));
                break;

            case '?' when Mode == RbMode.IO:
                MemFlag = _reader.Peek() != -1;
                break;
            #endregion IO Operators

            #region Map Operators
            case '+' when Mode == RbMode.Map:
                StepCursor();
                Stack.Push(Utilities.GetNumber(CurrentSymbol));
                break;

            case '-' when Mode == RbMode.Map && Stack.Any:
                StepCursor();
                CurrentSymbol = Utilities.GetSymbol(Stack.Pop());
                break;

            case '*' when Mode == RbMode.Map:
                StepCursor();
                CurrentSymbol = ' ';
                break;

            case '#' when Mode == RbMode.Map && Stack.AtleastTwo:
                if (!Stack.Collection[0].IsInt32() || !Stack.Collection[1].IsInt32())
                    throw new NumberOutOfRangeException("Value did not fit inside a 32bit integer");

                Y = Utilities.Wrap((int)Stack.Pop(), Map.Height);
                X = Utilities.Wrap((int)Stack.Pop(), Map.Width);
                Mode = RbMode.Traversal;
                step = false;
                break;

            case '>' when Mode == RbMode.Map:
                Map.Resize(Map.Width + 1, Map.Height);
                break;

            case '<' when Mode == RbMode.Map && Map.Width > 1:
                Map.Resize(Map.Width - 1, Map.Height);
                break;

            case 'v' when Mode == RbMode.Map:
                Map.Resize(Map.Width, Map.Height + 1);
                break;

            case '^' when Mode == RbMode.Map && Map.Height > 1:
                if (Map.Height - 1 < 1)
                    throw RbException.Wraps(new InvalidOperationException("Can not reduce height of the map"));
                Map.Resize(Map.Width, Map.Height - 1);
                break;

            case 'W' when Mode == RbMode.Map:
                Stack.Push(new BigInteger(Map.Width));
                break;

            case 'H' when Mode == RbMode.Map:
                Stack.Push(new BigInteger(Map.Height));
                break;

            case 'X' when Mode == RbMode.Map:
                Stack.Push(new BigInteger(X));
                break;

            case 'Y' when Mode == RbMode.Map:
                Stack.Push(new BigInteger(Y));
                break;
            #endregion Map Operators

            default:
                break;
        }

        if (step)
            StepCursor();

        return true;
    }

    public void StepCursor()
    {
        (State.X, State.Y) = Utilities.BoxWrap(
            State.X + (Direction.HasFlag(FlowDirection.Left) ? -1 : 0) + (Direction.HasFlag(FlowDirection.Right) ? 1 : 0),
            State.Y + (Direction.HasFlag(FlowDirection.Up) ? -1 : 0) + (Direction.HasFlag(FlowDirection.Down) ? 1 : 0),
            State.Map.Width, State.Map.Height);
    }

    public bool TryReadDigits(out BigInteger value)
    {
        StringBuilder sb = new();
        while (CurrentSymbol >= '0' && CurrentSymbol <= '9')
        {
            sb.Append(CurrentSymbol);
            StepCursor();
        }

        return BigInteger.TryParse(sb.ToString(), out value);
    }
}