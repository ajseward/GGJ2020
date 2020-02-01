namespace AnimeDiseaseGame
{
    public static class DungeonUtility
    {
        public static TileType GetOppositeTile(TileType tileType)
        {
            switch (tileType)
            {
                default:
                case TileType.None:
                    return TileType.None;
                case TileType.Up:
                    return TileType.Down;
                case TileType.Left:
                    return TileType.Right;
                case TileType.Right:
                    return TileType.Left;
                case TileType.Down:
                    return TileType.Up;
            }
        }
    }
}