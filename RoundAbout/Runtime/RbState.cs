namespace RoundAbout.Runtime;

public class RbState
{
    public RbMap Map { get; }
    public RbHeap Heap { get; }
    public RbStack Stack { get; }

    public int X { get => _x; set { _x = value; LocationChanged?.Invoke(value, _y); } }
    public int Y { get => _y; set { _y = value; LocationChanged?.Invoke(_x, value); } }

    public FlowDirection Direction { get => _direction; set { _direction = value; DirectionChanged?.Invoke(value); } }
    public RbMode Mode { get => _mode; set { _mode = value; ModeChanged?.Invoke(value); } }
    public bool MemFlag { get => _memFlag; set { _memFlag = value; MemFlagChanged?.Invoke(value); } }

    public bool RespectFlow { get => Mode == RbMode.Traversal || (Mode == RbMode.FlowTesting && MemFlag); }

    public char CurrentSymbol { get => Map.Content[Y, X]; set { Map.Content[Y, X] = value; MapSymbolChanged?.Invoke(value, X, Y); } }

    public bool Stopped { get; set; }

    private bool _memFlag;
    private int _x;
    private int _y;
    private FlowDirection _direction;
    private RbMode _mode;

    public RbState(RbMap map, RbHeap heap, RbStack stack, bool memflag, int x, int y, FlowDirection direction, RbMode mode)
    {
        Map = map;
        Heap = heap;
        Stack = stack;
        X = x;
        Y = y;
        Direction = direction;
        MemFlag = memflag;
        Mode = mode;
    }

    public event Action<bool>? MemFlagChanged;
    public event Action<FlowDirection>? DirectionChanged;
    public event Action<RbMode>? ModeChanged;
    public event Action<char, int, int>? MapSymbolChanged;
    public event Action<int, int>? LocationChanged;
}