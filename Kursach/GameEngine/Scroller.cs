using Kursach.Models;

namespace Kursach.GameEngine;

class Scroller
{
    public Tile[,] MapView(Tile[,] map)
    {
        Tile[,] mapAppereance = new Tile[7, 100];

        int windowHeight = 7;
        int windowWidth = 100;

        for (int y = 0; y < windowHeight; y++)
        {
            for (int x = 0; x < windowWidth; x++)
            {
                if (x == 0 || x == windowWidth - 1)
                {
                    mapAppereance[y, x] = new Tile('|', TileType.Map);
                }
                else if (y == 0 || y == windowHeight - 1)
                {
                    mapAppereance[y, x] = new Tile('#', TileType.Map);
                }
                else
                {
                    mapAppereance[y, x] = map[y - 1, x - 1];
                }
            }
        }

        return mapAppereance;
    }

    public Tile[,] ScrollLeft(Tile[,] mapView, Tile[,] fullMap, ref int width)
    {
        width++;
        for (int y = 1; y < mapView.GetLength(0) - 1; y++)
        {
            for (int x = 1; x < mapView.GetLength(1) - 2; x++)
            {
                if (mapView[y, x].Type == TileType.Player)
                    continue;
                if (mapView[y, x + 1].Type == TileType.Player)
                {
                    mapView[y, x] = mapView[y, x + 2];
                    continue;
                }
                mapView[y, x] = mapView[y, x + 1];
            }

            if (fullMap.GetLength(1) > width)
            {
                mapView[y, mapView.GetLength(1) - 2] = fullMap[y - 1, width];
            }
            else
            {
                mapView[y, mapView.GetLength(1) - 2] = new Tile(' ', TileType.Empty);
            }
        }
        return mapView;
    }
}