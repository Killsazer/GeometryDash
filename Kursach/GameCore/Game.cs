using Kursach.Models;
using Kursach.GameEngine;
using Kursach.Menu;

namespace Kursach.GameCore;

class Game
{
    private readonly MapRenderer mapRenderer = new MapRenderer();
    private readonly MapLoader mapLoader = new MapLoader();
    private readonly WindowScroller scroller = new WindowScroller();
    private readonly PlayerController playerController = new PlayerController();
    private const int _FrameDelay = 150;
    private const int _PlayerOffset = 3;

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

        while (HasObstaclesAhead(mapView, x))
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
                (width, mapView) = Jump(width, mapView, fullMap);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                continue;
            }
            mapView = scroller.ScrollLeft(mapView, fullMap, ref width);
            Thread.Sleep(_FrameDelay);
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
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                return true;
            }
        }
        return false;
    }
    private (int width, Tile[,] mapView) Jump(int width, Tile[,] mapView, Tile[,] fullMap)
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
                Thread.Sleep(_FrameDelay);
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
    private bool HasObstaclesAhead(Tile[,] map, int xPlayer)
    {
        if (xPlayer - _PlayerOffset > 0)
        {
            xPlayer -= _PlayerOffset; //задля того щоб пройшло трохи часу пере виграшем
        }
        for (int y = 1; y < map.GetLength(0) - 1; y++)
        {
            for (int x = xPlayer; x < map.GetLength(1) - 1; x++)
            {
                if (map[y, x].Type != TileType.Empty && map[y, x].Type != TileType.Player)
                {
                    return true;
                }
            }
        }
        return false;
    }
}