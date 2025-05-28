using Kursach.Models;
using Kursach.GameEngine;

namespace Kursach.GameCore;

class Game
{
    private readonly MapRenderer mapEngine = new MapRenderer();
    private readonly MapLoader mapLoader = new MapLoader();
    private readonly Scroller scroller = new Scroller();
    private readonly GameCondition gameStateChecker = new GameCondition();
    private const int FrameDelay = 150;

    public void StartGame()
    {
        Console.Clear();
        Tile[,] map = mapLoader.LoadFromFile();
        while (gameStateChecker.HasNonEmptyTiles(map))
        {
            mapEngine.PrintMap(map);
            map = scroller.ScrollLeft(map);
            Thread.Sleep(FrameDelay);
        }
        mapEngine.PrintMap(map);
    }
}