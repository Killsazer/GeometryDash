using Kursach.Models;
using Kursach.GameEngine;

namespace Kursach.GameCore;

class PlayerController
{
    public Tile[,] JumpFrameUp(Tile[,] map)
    {
        var (x, y) = FindPlayer(map);

        map[y - 1, x + 1] = new Tile('□', TileType.Player);
        map[y, x] = new Tile(' ', TileType.Empty);
        return map;
    }
    public Tile[,] JumpFrameDown(Tile[,] map, int height = 2)
    {
        var (x, y) = FindPlayer(map);

        map[y + 1, x + 1] = new Tile('□', TileType.Player);
        map[y, x] = new Tile(' ', TileType.Empty);
        return map;
    }

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
}