﻿namespace IdleEngine.Model;

public readonly struct Position(int q, int r)
{
    // See this page for an explanation of the cubical/axial coordinate system.
    public readonly int Q { get; } = q;
    public readonly int R { get; } = r;
    public readonly int S { get => (-Q -R); }

    public (int col, int row) ToOddQ => (Q, (R + (Q - (Q &1)) / 2));

    public static bool operator ==(Position a, Position b) => (a.Q == b.Q && a.R == b.R);
    public static bool operator !=(Position a, Position b) => !(a == b);

    public static Position operator -(Position a, Position b) => new(a.Q - b.Q, a.R - b.R);

    public static int CalculateDistance(Position a, Position b)
    {
        var vector = a - b;
        return Math.Abs((Math.Abs(vector.Q) + Math.Abs(vector.R) + Math.Abs(vector.S)) /2);
    }

    public int CalculateDistance(Position other) => 
        Math.Abs(
            (
                Math.Abs(Q - other.Q) +
                Math.Abs(R - other.R) +
                Math.Abs(S - other.S)
            ) / 2
        );

    public override string ToString()
    {
        return $"({Q}, {R})";
    }
}
