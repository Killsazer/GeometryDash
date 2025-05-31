namespace Kursach.Menu;

class WinMenu : EndMenuInterface
{
    public void Print()
    {
        Console.WriteLine();
        string text = "You Win!";
        int xText = (Console.WindowWidth - text.Length) / 2;
        Console.WriteLine(new string(' ', xText) + text);

        text = "Press any key to exit...";
        xText = (Console.WindowWidth - text.Length) / 2;
        Console.WriteLine(new string(' ', xText) + text);
        Console.ReadKey(true);
    }
}