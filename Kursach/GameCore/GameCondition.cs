using Kursach.Models;

namespace Kursach.GameCore;

class GameCondition
{
    private readonly PlayerController playerController = new PlayerController();
    public bool HasNonEmptyTiles(Tile[,] map)
    {
        int xPlayer = playerController.FindPlayer(map).X;
        if (xPlayer - 3 > 0)
        {
            xPlayer -= 3; //задля того щоб пройшло трохи часу пере виграшем
        }
        for (int y = 1; y < map.GetLength(0) - 1; y++)
        {
            for (int x = xPlayer; x < map.GetLength(1) - 1; x++)
            {
                if (map[y, x].Type != TileType.Empty && map[y, x].Type != TileType.Player)
                {
                    return true;
                }
            }
        }
        return false;
    }
}