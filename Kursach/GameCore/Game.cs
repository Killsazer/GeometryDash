using Kursach.Models;
using Kursach.GameEngine;
using Kursach.Menu;

namespace Kursach.GameCore;

class Game
{
    private readonly MapRenderer mapRenderer = new MapRenderer();
    private readonly MapLoader mapLoader = new MapLoader();
    private readonly Scroller scroller = new Scroller();
    private readonly GameCondition gameStateChecker = new GameCondition();
    private readonly PlayerController playerController = new PlayerController();
    private const int FrameDelay = 150;

    public void StartGame()
    {
        Console.Clear();

        Tile[,] map = mapLoader.LoadFromFile();
        map = scroller.Map(map);
        bool deathCondition = false;
        while (gameStateChecker.HasNonEmptyTiles(map))
        {
            mapRenderer.PrintMap(map);
            var (x, y) = playerController.FindPlayer(map);
            if (map[y, x + 1].Type != TileType.Empty || map[y, x - 1].Type != TileType.Empty)
            {
                DeathMenu deathMenu = new DeathMenu();
                deathMenu.Print();
                deathCondition = true;
                break;
            }
            if (SpacePressed())
            {
                foreach (var jumpFrame in playerController.Jump(map))
                {
                    map = jumpFrame;
                    mapRenderer.PrintMap(map);
                    Thread.Sleep(FrameDelay);
                }
                continue;
            }
            map = scroller.ScrollLeft(map);
            Thread.Sleep(FrameDelay);
        }
        if (!deathCondition)
        {
            mapRenderer.PrintMap(map);
            WinMenu winMenu = new WinMenu();
            winMenu.Print();
        }
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