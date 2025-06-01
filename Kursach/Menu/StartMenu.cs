namespace Kursach.Menu;

class StartMenu
{
    private readonly ConsolePrinter consolePrinter = new ConsolePrinter();
    private readonly MenuNavigator menuNavigator;
    public StartMenu()
    {
        menuNavigator = new MenuNavigator(StartGame);
    }
    public bool MenuGenerator()
    {
        Console.Clear();

        List<string> lines = new List<string>
        {
            new("Welcome to Geometry Dash!"),
            new("If you're ready to try to pass the level: press ENTER!"),
            new("If you want to exit the game: press ESC :(")
        };

        int y = Console.CursorTop;

        for (int i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            int x = (Console.WindowWidth - line.Length) / 2;

            if (i == 0)
                consolePrinter.PrintText(x, y, line);
            else if (i == 2)
            {
                x = (Console.WindowWidth - lines[1].Length) / 2; //вирівнювання в одному лінію з попереднім рядком
                consolePrinter.PrintText(x, y, line);
            }
            else
                consolePrinter.PrintText(x, y, line);

            y++;
            if (i == 0) y++; // відступ після першого рядка
        }

        return menuNavigator.PressedKey();
    }

    public void StartGame()
    {
        Console.Clear();
        var text = "Starting the game";
        int x = (Console.WindowWidth - text.Length - 3) / 2;
        int y = Console.CursorTop;
        consolePrinter.PrintText(x, y, text);
        for (int i = 0; i < 3; i++)
        {
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.Write(text);
            foreach (char letter in "...")
            {
                Thread.Sleep(300);
                Console.Write(letter);
            }
            Thread.Sleep(500);
        }

        Console.Clear();
        Thread.Sleep(500);
    }
}