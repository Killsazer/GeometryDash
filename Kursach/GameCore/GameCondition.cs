using Kursach.Models;

namespace Kursach.GameCore;

class GameCondition
{
    public bool HasNonEmptyTiles(Tile[,] map)
    {
        for (int y = 1; y < map.GetLength(0) - 1; y++)
        {
            for (int x = 1; x < map.GetLength(1) - 1; x++)
            {
                if (map[y, x].Type != TileType.Empty)
                {
                    return true;
                }
            }
        }
        return false;
    }
}