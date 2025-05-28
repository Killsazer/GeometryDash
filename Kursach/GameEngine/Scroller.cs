using Kursach.Models;

namespace Kursach.GameEngine;

class Scroller
{
    public Tile[,] ScrollLeft(Tile[,] map)
    {
        for (int y = 1; y < map.GetLength(0) - 1; y++)
        {
            for (int x = 1; x < map.GetLength(1) - 2; x++) //уникаємо копіювання '|' 
            {
                map[y, x] = map[y, x + 1];
            }
        }
        return map;
    }
}