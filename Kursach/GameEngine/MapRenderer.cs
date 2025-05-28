using System.Text;
using Kursach.Models;

namespace Kursach.GameEngine;

class MapRenderer
{
    private readonly StringBuilder frame = new StringBuilder();
    public void PrintMap(Tile[,] map)
    {
        frame.Clear();

        int xCoord = (Console.WindowWidth - map.GetLength(1)) / 2;
        int yCoord = (Console.WindowHeight - map.GetLength(0)) / 2;

        for (int i = 0; i < yCoord; i++)
        {
            frame.AppendLine();
        }

        for (int y = 0; y < map.GetLength(0); y++)
        {
            frame.Append(' ', xCoord);
            for (int x = 0; x < map.GetLength(1); x++)
            {
                frame.Append(map[y, x].Symbol);
            }
            frame.AppendLine();
        }

        Console.SetCursorPosition(0, 0);
        Console.Write(frame.ToString());
    }
}