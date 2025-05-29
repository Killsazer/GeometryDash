using Kursach.Models;

namespace Kursach.GameEngine;

class Scroller
{
    public Tile[,] ScrollLeft(Tile[,] map)
    {
        for (int y = 1; y < map.GetLength(0) - 1; y++)
        {
            for (int x = 1; x < map.GetLength(1) - 2; x++)
            {
                if (map[y, x].Type == TileType.Player)
                    continue;
                if (map[y, x + 1].Type == TileType.Player)
                {
                    map[y, x] = map[y, x + 2];
                    continue;
                }
                map[y, x] = map[y, x + 1];
            }
            map[y, map.GetLength(1) - 2] = new Tile(' ', TileType.Empty);
        }
        return map;
    }
}