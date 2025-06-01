using Kursach.Utils;

namespace Kursach.Menu;

public static class LevelSelectionMenu
{
    public static string SelectLevel()
    {
        Console.Clear();
        string text = "Choose the level:\n1. Beta level\n2. First level";
        Console.WriteLine(text);
        while (true)
        {
            ConsoleHelper.ClearInputBuffer();
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    return "BetaLevel.txt";
                case ConsoleKey.D2:
                    return "FirstLevel.txt";
                default:
                    Console.Clear();
                    Console.Write("Invalid key pressed.\n\n" + text);
                    break;
            }
        }
    }
}