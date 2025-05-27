namespace GeometryDashLogicStarter;

using GeometryDashFieldMap;
using GeometryDashModelsTile;
using GeometryDashModelsTileType;
using GeometryDashFieldMapLoader;

class Starter
{
    private MapRenderer mapEngine = new MapRenderer();

    public void StartGame()
    {
        Console.Clear();
        MapLoader mapLoader = new MapLoader();
        Tile[,] map = mapLoader.MapConvertor();
        while (RepCondition(map))
        {
            mapEngine.PrintMap(map);
            map = mapEngine.ScrollLeft(map);
            Thread.Sleep(150);
        }
        mapEngine.PrintMap(map);
    }

    private bool RepCondition(Tile[,] map)
    {
        bool repCondition = false;
        for (int y = 1; y < map.GetLength(0) - 1; y++)
        {
            for (int x = 1; x < map.GetLength(1) - 1; x++)
            {
                if (map[y, x].Type != TileType.Empty)
                {
                    repCondition = true;
                }
            }
        }
        return repCondition;
    }
}