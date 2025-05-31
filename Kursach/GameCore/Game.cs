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

        Tile[,] mapView = mapLoader.LoadFromFile();
        mapView = scroller.MapView(mapView);
        bool deathCondition = false;
        while (gameStateChecker.HasNonEmptyTiles(mapView))
        {
            mapRenderer.PrintMap(mapView);
            var (x, y) = playerController.FindPlayer(mapView);
            if (mapView[y, x + 1].Type != TileType.Empty || mapView[y, x - 1].Type != TileType.Empty)
            {
                DeathMenu deathMenu = new DeathMenu();
                deathMenu.Print();
                deathCondition = true;
                break;
            }
            if (SpacePressed())
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (i <= 2)
                    {
                        mapView = scroller.ScrollLeft(mapView);
                        mapView = playerController.JumpFrameUp(mapView);
                    }
                    else
                    {
                        mapView = scroller.ScrollLeft(mapView);
                        mapView = playerController.JumpFrameDown(mapView);
                    }
                    mapRenderer.PrintMap(mapView);
                    if (i != 4)
                    {
                        Thread.Sleep(FrameDelay);
                    }
                }
                // foreach (var jumpFrame in playerController.Jump(mapView))
                // {
                //     mapView = jumpFrame;
                //     mapRenderer.PrintMap(mapView);
                //     Thread.Sleep(FrameDelay);
                // }
                continue;
            }
            mapView = scroller.ScrollLeft(mapView);
            Thread.Sleep(FrameDelay);
        }
        if (!deathCondition)
        {
            mapRenderer.PrintMap(mapView);
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