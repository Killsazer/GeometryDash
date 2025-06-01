using Kursach.Models;

namespace Kursach.GameCore;

class PlayerController
{
    public Tile[,] MovePlayerUp(Tile[,] map)
    {
        MovePlayer(map, -1);
        return map;
    }
    public Tile[,] MovePlayerDown(Tile[,] map, int height = 2)
    {
        MovePlayer(map, +1);
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
    private Tile[,] MovePlayer(Tile[,] map, int deltaY)
    {
        var (x, y) = FindPlayer(map);
        map[y + deltaY, x + 1] = new Tile('□', TileType.Player);
        map[y, x] = new Tile(' ', TileType.Empty);
        return map;
    }
}