namespace RoundAbout.Runtime;

[Flags]
public enum FlowDirection
{
    None = 0,
    Up = 1,
    Down = 2,
    Left = 4,
    Right = 8,
    LeftUp = Left | Up,
    LeftDown = Left | Down,
    RightUp = Right | Up,
    RightDown = Right | Down,
}