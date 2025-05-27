namespace GeometryDashMenu;

class Menu
{
    public void StartMenu()
    {
        Console.Clear();
        var text = "Welcome to Geometry Dash!";
        var x = (Console.WindowWidth - text.Length) / 2;
        var y = Console.CursorTop;

        PrintFirstLine(x, y, text);

        text = "If you're ready to try to pass the level: press ENTER!";
        x = (Console.WindowWidth - text.Length) / 2;
        y += 2;
        PrintText(x, y, text);

        text = "If you want to exit the game: press ESC :(";
        y++;
        PrintText(x, y, text);

        PressedKey();
    }

    private void PrintText(in int x, in int y, in string text)
    {
        Console.SetCursorPosition(x, y);
        foreach (char letter in text)
        {
            Console.Write(letter);
            Thread.Sleep(50);
        }
    }

    private void PrintFirstLine(in int x, in int y, in string text)
    {
        Console.SetCursorPosition(x, y);
        foreach (char letter in text)
        {
            if (letter == 'G')
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
        int x;
        int y;
        string text;

        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.Escape:
                break;
            case ConsoleKey.Enter:
                Console.Clear();
                text = "Starting the game";
                x = (Console.WindowWidth - text.Length-3) / 2;
                y = Console.CursorTop;
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
                break;
            default:
                Console.Clear();
                text = "Invalid key pressed. Please press ENTER to start or ESC to exit.";
                x = (Console.WindowWidth - text.Length) / 2;
                y = Console.CursorTop;
                Console.SetCursorPosition(x, y);
                Console.WriteLine(text);
                PressedKey();
                break;
        }
    }
}