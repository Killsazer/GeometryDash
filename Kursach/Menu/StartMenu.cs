namespace GeometryDashMenu;

class StartMenu
{
    public void Main()
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
                PrintText(x, y, line);
            else if (i == 2)
            {
                x = (Console.WindowWidth - lines[1].Length) / 2; //вирівнювання в одному лінію з попереднім рядком
                PrintText(x, y, line);
            }
            else
                PrintText(x, y, line);

            y++;
            if (i == 0) y++; // відступ після першого рядка
        }

        PressedKey();
    }

    private void PrintText(in int x, in int y, in string text)
    {
        Console.SetCursorPosition(x, y);
        foreach (char letter in text)
        {
            if (letter == 'G' && text.Contains("Geometry Dash")) // кольоровий напис "Geometry Dash!"
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.Write(letter);
            Thread.Sleep(50);
        }
        Console.ResetColor();
    }

    private void PressedKey()
    {
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    return;

                case ConsoleKey.Enter:
                    StartGame();
                    return;

                default:
                    Console.Clear();
                    var text = "Invalid key pressed. Please press ENTER to start or ESC to exit.";
                    int x = (Console.WindowWidth - text.Length) / 2;
                    int y = Console.CursorTop;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(text);
                    break;
            }
        }
    }

    private void StartGame()
    {
        Console.Clear();
        var text = "Starting the game";
        int x = (Console.WindowWidth - text.Length - 3) / 2;
        int y = Console.CursorTop;
        PrintText(x, y, text);
        for (int i = 0; i < 3; i++)
        {
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.Write(text);
            foreach (char letter in "...")
            {
                Thread.Sleep(500);
                Console.Write(letter);
            }
            Thread.Sleep(500);
        }
        // Here you would typically start the game logic.
    }
}