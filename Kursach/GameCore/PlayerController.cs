using Kursach.Models;

namespace Kursach.GameCore;

class PlayerController
{
    public IEnumerable<Tile[,]> Jump(Tile[,] map, int height = 2)
    {
        var (x, y) = FindPlayer(map);

        // ПІДЙОМ: y - 1
        for (int i = 1; i <= height; i++)
        {
            int newY = y - 1;
            int newX = x + 1;

            // Рух гравця
            map[newY, newX] = new Tile('□', TileType.Player);
            map[y, x] = new Tile(' ', TileType.Empty);
            y = newY;
            x = newX;

            yield return map;
        }

        // СПУСК: y + 1
        while (true)
        {
            int newY = y + 1;
            int newX = x + 1;

            if (IsDeath(map, newX, newY))
                throw new Exception("You're dead (.");

            map[newY, newX] = new Tile('□', TileType.Player);
            map[y, x] = new Tile(' ', TileType.Empty);
            y = newY;
            x = newX;

            yield return map;
        }
    }


    // public Tile[,] ApplyGravity(Tile[,] map)
    // {
    //     var (x, y) = FindPlayer(map);
    //     int newY = y + 1;
    //     int newX = x + 1;

    //     if (map[newY, newX].Type == TileType.Empty)
    //     {
    //         map[newY, newX] = new Tile('□', TileType.Player);
    //         map[y, x] = new Tile(' ', TileType.Empty);
    //     }

    //     return map;
    // }
    public (int X, int Y) FindPlayer(Tile[,] map)
    {

        for (int y = 1; y < map.GetLength(0) - 1; y++)
        {
            for (int x = 1; x < map.GetLength(1) - 1; x++)
            {
                if (map[y, x].Type == TileType.Player)
                    return (x, y);
            }
        }
        throw new Exception("Player not found on the map.");
    }

    private bool IsDeath(Tile[,] map, int x, int y)
    {
        // Перевірка меж
        if (y < 0 || y >= map.GetLength(0) || x < 0 || x >= map.GetLength(1))
            return true;

        // Смертельна клітинка
        var type = map[y, x].Type;
        return type != TileType.Empty && type != TileType.Map;
    }
}