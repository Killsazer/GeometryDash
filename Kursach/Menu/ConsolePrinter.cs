namespace Kursach.Menu;

class ConsolePrinter
{
    public void PrintText(in int x, in int y, in string text)
    {
        Console.SetCursorPosition(x, y);

        bool isTitle = text.Contains("Geometry Dash");

        foreach (char letter in text)
        {
            if (isTitle && letter == 'G') // кольоровий напис "Geometry Dash!"
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.Write(letter);
            Thread.Sleep(30);
        }
        Console.ResetColor();
    }
}