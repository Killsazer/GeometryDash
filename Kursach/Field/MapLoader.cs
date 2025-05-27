namespace GeometryDashFieldMapLoader;

using GeometryDashModelsTile;
using GeometryDashModelsTileType;

class MapLoader
{
    public Tile[,] MapConvertor()
    {
        string currentDir = Directory.GetCurrentDirectory();
        currentDir = Path.GetFullPath(Path.Combine(currentDir, "..", "..", ".."));
        string betaLevelDir = Path.Combine(currentDir, "Field", "Levels", "BetaLevel.txt");

        string[] lines = File.ReadAllLines(betaLevelDir);
        int width = lines[0].Length;
        int height = lines.Length;

        Tile[,] tiles = new Tile[height, width];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                char symbol = lines[y][x];
                TileType type = symbol switch
                {
                    ' ' => TileType.Empty,
                    '■' => TileType.Block,
                    '^' => TileType.Spike,
                    '□' => TileType.Player,
                    _ => TileType.Map
                };
                tiles[y, x] = new Tile(symbol, type);
            }
        }
        return tiles;
    }
}