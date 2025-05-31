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

    public bool StartGame()
    {
        Console.Clear();

        // fullMap = scroller.ScrollLeft(fullMap);
        Tile[,] fullMap = mapLoader.LoadFromFile();
        Tile[,] mapView = scroller.MapView(fullMap);
        int width = mapView.GetLength(1);
        width++;
        mapView = scroller.ScrollLeft(mapView, fullMap, width);
        bool deathCondition = false;
        bool repCondition = false;
        while (gameStateChecker.HasNonEmptyTiles(mapView))
        {
            mapRenderer.PrintMap(mapView);
            var (x, y) = playerController.FindPlayer(mapView);
            if (mapView[y, x + 1].Type == TileType.Spike || mapView[y, x - 1].Type == TileType.Spike)
            {
                string text = "You lose:(";
                EndMenu endMenu = new EndMenu();
                repCondition = endMenu.Print(text);
                deathCondition = true;
                break;
            }
            if (SpacePressed())
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (i <= 2)
                    {
                        width++;
                        mapView = scroller.ScrollLeft(mapView, fullMap, width);
                        mapView = playerController.JumpFrameUp(mapView);
                        // (x, y) = playerController.FindPlayer(mapView);
                        // mapRenderer.PrintMap(mapView);
                        // if (mapView[y, x + 1].Type != TileType.Empty)
                        // {
                        //     DeathMenu deathMenu = new DeathMenu();
                        //     deathMenu.Print();
                        //     deathCondition = true;
                        //     break;
                        // }
                    }
                    else
                    {
                        width++;
                        mapView = scroller.ScrollLeft(mapView, fullMap, width);
                        mapView = playerController.JumpFrameDown(mapView);
                    }
                    mapRenderer.PrintMap(mapView);
                    if (i != 4)
                    {
                        Thread.Sleep(FrameDelay);
                    }
                }
                continue;
            }
            width++;
            mapView = scroller.ScrollLeft(mapView, fullMap, width);
            Thread.Sleep(FrameDelay);
        }
        if (!deathCondition)
        {
            mapRenderer.PrintMap(mapView);
            string text = "You win! Congratulations!";
            EndMenu endMenu = new EndMenu();
            repCondition = endMenu.Print(text);
        }
        return repCondition;
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