using Kursach.Menu;
using Kursach.Models;

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
        string fileName = LevelSelectionMenu.SelectLevel();

        string exeDir = AppContext.BaseDirectory; // для exe
        return Path.Combine(exeDir, "Levels", fileName);
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