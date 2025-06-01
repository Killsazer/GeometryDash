namespace Kursach.Menu;

using Kursach.Utils;

class EndMenu
{
    public bool Print(string text)
    {
        Console.WriteLine();
        int xText = (Console.WindowWidth - text.Length) / 2;
        Console.WriteLine(new string(' ', xText) + text);


        text = "If you want to try again - press enter!";
        xText = (Console.WindowWidth - text.Length) / 2;
        Console.WriteLine(new string(' ', xText) + text);
        text = "Or press any other key to exit...";
        xText = (Console.WindowWidth - text.Length) / 2;
        Console.WriteLine(new string(' ', xText) + text);
        ConsoleHelper.ClearInputBuffer();
        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.Enter:
                return true;
            default:
                return false;
        }
    }
}