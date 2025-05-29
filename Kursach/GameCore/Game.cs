using Kursach.Models;
using Kursach.GameEngine;

namespace Kursach.GameCore;

class Game
{
    private readonly MapRenderer mapEngine = new MapRenderer();
    private readonly MapLoader mapLoader = new MapLoader();
    private readonly Scroller scroller = new Scroller();
    private readonly GameCondition gameStateChecker = new GameCondition();
    private readonly PlayerController playerController = new PlayerController();
    private const int FrameDelay = 150;

    public void StartGame()
    {
        Console.Clear();
        Tile[,] map = mapLoader.LoadFromFile();
        while (gameStateChecker.HasNonEmptyTiles(map))
        {
            // var (x, y) = playerController.FindPlayer(map);
            mapEngine.PrintMap(map);
            // if (map[y, x + 1].Type != TileType.Empty)
            //     throw new Exception("You're dead");
            // if (SpacePressed())
            // {
            //     foreach (var jumpFrame in playerController.Jump(map))
            //     {
            //         map = jumpFrame;
            //         (x, y) = playerController.FindPlayer(map);
            //         map = scroller.ScrollLeft(map);
            //         mapEngine.PrintMap(map);
            //         Thread.Sleep(FrameDelay);
            //     }
            //     continue;
            // }
            map = scroller.ScrollLeft(map);
            Thread.Sleep(FrameDelay);
        }
        mapEngine.PrintMap(map);
    }
    private bool SpacePressed()
    {
        bool res = false;
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Spacebar)
            {
                res = true;
            }
        }
        return res;
    }
}