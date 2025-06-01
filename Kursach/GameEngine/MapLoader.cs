using Kursach.Models;
using Kursach.Utils;

namespace Kursach.GameEngine;

class MapLoader
{
    public Tile[,] LoadFromFile()
    {
        try
        {
            string levelDir = GetLevelPath();

            string[] lines = File.ReadAllLines(levelDir);
            int height = lines.Length;
            int width = lines[0].Length;

            Tile[,] tiles = new Tile[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    char symbol = lines[y][x];
                    TileType type = GetTileTypeFromSymbol(symbol);
                    tiles[y, x] = new Tile(symbol, type);
                }
            }
            return tiles;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Press any key to exit.");
            Console.ReadKey();
            Environment.Exit(0);
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading level: {ex.Message}");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            Environment.Exit(1);
            return null;
        }
    }
    private string GetLevelPath()
    {
        Console.Clear();
        string text = "Choose the level:\n1. Beta level\n2. First level";
        Console.WriteLine(text);
        string fileName = "";
        bool cond = true;
        while (cond)
        {
            ConsoleHelper.ClearInputBuffer();
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    fileName = "BetaLevel.txt";
                    cond = false;
                    break;
                case ConsoleKey.D2:
                    fileName = "FirstLevel.txt";
                    cond = false;
                    break;
                default:
                    Console.Clear();
                    Console.Write("Invalid key pressed.\n\n" + text);
                    break;
            }
        }

        Console.Clear();

        string exeDir = AppContext.BaseDirectory; // для exe
        return Path.Combine(exeDir, "Field", "Levels", fileName);
    }
    private TileType GetTileTypeFromSymbol(char symbol)
    {
        return symbol switch
        {
            ' ' => TileType.Empty,
            '▲' => TileType.Spike,
            '□' => TileType.Player,
            _ => TileType.Map
        };
    }
}