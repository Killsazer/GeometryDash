using Kursach.Models;

namespace Kursach.GameEngine;

class MapLoader
{
    private const string LevelFileName = "BetaLevel.txt";
    public Tile[,] LoadFromFile()
    {
        string betaLevelDir = GetLevelPath(LevelFileName);

        string[] lines = File.ReadAllLines(betaLevelDir);
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
    private string GetLevelPath(string fileName)
    {
        string currentDir = Directory.GetCurrentDirectory();
        currentDir = Path.GetFullPath(Path.Combine(currentDir, "..", "..", ".."));
        return Path.Combine(currentDir, "Field", "Levels", fileName);
    }
    private TileType GetTileTypeFromSymbol(char symbol)
    {
        return symbol switch
        {
            ' ' => TileType.Empty,
            '■' => TileType.Block,
            '^' => TileType.Spike,
            '□' => TileType.Player,
            _ => TileType.Map
        };
    }
}