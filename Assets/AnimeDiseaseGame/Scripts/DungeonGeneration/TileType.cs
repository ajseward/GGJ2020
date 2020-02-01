using System;

namespace AnimeDiseaseGame
{
    [Flags]
    public enum TileType
    {
        None = 0,
        Up = 1,
        Left = 1 << 1,
        Right = 1 << 2,
        Down = 1 << 3,
    }
}