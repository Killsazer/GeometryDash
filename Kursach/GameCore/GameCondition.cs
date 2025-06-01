using Kursach.Models;

namespace Kursach.GameCore;

class GameCondition
{
    private const int PlayerOffset = 3;
    public bool HasObstaclesAhead(Tile[,] map, int xPlayer)
    {
        if (xPlayer - PlayerOffset > 0)
        {
            xPlayer -= PlayerOffset; //задля того щоб пройшло трохи часу пере виграшем
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