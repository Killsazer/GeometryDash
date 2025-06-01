namespace Kursach.Menu;

using Kursach.Utils;

class MenuNavigator
{
    private readonly Action startGame;

    public MenuNavigator(Action startGame)
    {
        this.startGame = startGame;
    }
    public bool PressedKey()
    {
        while (true)
        {
            ConsoleHelper.ClearInputBuffer();
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    return false;

                case ConsoleKey.Enter:
                    startGame.Invoke();
                    return true;

                default:
                    Console.Clear();
                    var text = "Invalid key pressed. Please press ENTER to start or ESC to exit.";
                    int x = Math.Max(0, (Console.WindowWidth - text.Length) / 2);
                    int y = Console.CursorTop;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(text);
                    break;
            }
        }
    }
}