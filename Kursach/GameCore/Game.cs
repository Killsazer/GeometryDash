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

        Tile[,] fullMap = mapLoader.LoadFromFile();
        Tile[,] mapView = scroller.MapView(fullMap);

        int width = mapView.GetLength(1);
        mapView = scroller.ScrollLeft(mapView, fullMap, ref width);
        var (x, y) = playerController.FindPlayer(mapView);

        bool deathCondition = false;
        bool repCondition = false;
        while (gameStateChecker.HasObstaclesAhead(mapView, x))
        {
            mapRenderer.PrintMap(mapView);
            (x, y) = playerController.FindPlayer(mapView);
            if (mapView[y, x + 1].Type == TileType.Spike || mapView[y, x - 1].Type == TileType.Spike)
            {
                (repCondition, deathCondition) = HandleLose();
                break;
            }
            if (IsSpacePressed())
            {
                (width, mapView) = JumpProcess(width, mapView, fullMap);
                continue;
            }
            mapView = scroller.ScrollLeft(mapView, fullMap, ref width);
            Thread.Sleep(FrameDelay);
        }
        if (!deathCondition)
        {
            repCondition = HandleWin(mapView);
        }
        return repCondition;
    }
    private bool IsSpacePressed()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Spacebar)
            {
                // Очищуємо буфер, щоб "зажатий" пробіл не накопичувався
                while (Console.KeyAvailable) Console.ReadKey(true);
                return true;
            }
        }
        return false;
    }
    private (int width, Tile[,] mapView) JumpProcess(int width, Tile[,] mapView, Tile[,] fullMap)
    {
        for (int i = 1; i <= 4; i++)
        {
            if (i <= 2)
            {
                mapView = scroller.ScrollLeft(mapView, fullMap, ref width);
                mapView = playerController.MovePlayerUp(mapView);
            }
            else
            {
                mapView = scroller.ScrollLeft(mapView, fullMap, ref width);
                mapView = playerController.MovePlayerDown(mapView);
            }
            mapRenderer.PrintMap(mapView);
            if (i != 4)
            {
                Thread.Sleep(FrameDelay);
            }
        }
        return (width, mapView);
    }
    private bool HandleWin(Tile[,] map)
    {
        mapRenderer.PrintMap(map);
        string text = "You win! Congratulations!";
        EndMenu endMenu = new EndMenu();
        return endMenu.Print(text);
    }
    private (bool repCondition, bool deathCondition) HandleLose()
    {
        string text = "You lose:(";
        EndMenu endMenu = new EndMenu();
        return (endMenu.Print(text), true);
    }
}