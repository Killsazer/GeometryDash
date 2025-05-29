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
                // Пропускаємо клітинку гравця і наступну після нього
                // if ((x == playerX - 1 && y == playerY) || (x == playerX && y == playerY))
                //     continue;
                if (map[y, x].Type == TileType.Player || map[y, x + 1].Type == TileType.Player)
                    continue;
                map[y, x] = map[y, x + 1];
            }
        }
        return map;
    }
}