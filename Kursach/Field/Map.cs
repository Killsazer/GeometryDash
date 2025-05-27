namespace GeometryDashFieldMap;

using System.Text;
using GeometryDashModelsTile;
using GeometryDashModelsTileType;

class MapRenderer
{
    public void PrintMap(Tile[,] map)
    {

        // int xCoord = (Console.WindowWidth - map.GetLength(1)) / 2;
        // int yCoord = (Console.WindowHeight - map.GetLength(0)) / 2;

        // Thread.Sleep(100);
        // Console.Clear();
        // for (int y = 0; y < map.GetLength(0); y++)
        // {
        //     Console.SetCursorPosition(xCoord, yCoord);
        //     for (int x = 0; x < map.GetLength(1); x++)
        //     {
        //         Console.Write(map[y, x].Symbol);
        //     }
        //     yCoord++;
        // }

        int xCoord = (Console.WindowWidth - map.GetLength(1)) / 2;
        int yCoord = (Console.WindowHeight - map.GetLength(0)) / 2;

        StringBuilder frame = new StringBuilder();

        // Додаємо порожні рядки зверху (yCoord разів)
        for (int i = 0; i < yCoord; i++)
        {
            frame.AppendLine();
        }

        for (int y = 0; y < map.GetLength(0); y++)
        {
            frame.Append(' ', xCoord); // Відступ зліва
            for (int x = 0; x < map.GetLength(1); x++)
            {
                frame.Append(map[y, x].Symbol);
            }
            frame.AppendLine();
        }

        Console.SetCursorPosition(0, 0);
        Console.Write(frame.ToString());
    }

    public Tile[,] ScrollLeft(Tile[,] map)
    {
        // Зсуваємо карту вліво і очищаємо останню (праву) клітинку, яка лишилась пустою після зсуву
        for (int y = 1; y < map.GetLength(0) - 1; y++)
        {
            for (int x = 1; x < map.GetLength(1) - 2; x++)
            {
                map[y, x] = map[y, x + 1];
            }
            map[y, map.GetLength(1) - 2] = new Tile(' ', TileType.Empty);
        }
        return map;
    }
}