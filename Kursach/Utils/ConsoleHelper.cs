namespace Kursach.Utils;

public static class ConsoleHelper
{
    public static void ClearInputBuffer()
    {
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }
    }
}