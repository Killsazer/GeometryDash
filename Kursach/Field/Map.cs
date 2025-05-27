namespace GeometryDashMap;

class Map
{
    public void MapGenerator()
    {
        Console.Clear();
        const int MapWidth = 100;
        const int MapHeight = 25;

        string[] currentWindow = new string[MapHeight];
        for (int i = 0; i < MapHeight; i++)
        {
            if (i == 0 || i == MapHeight - 1)
                currentWindow[i] = new string('-', MapWidth);
            else
                currentWindow[i] = "|" + new string(' ', MapWidth - 2) + "|";
        }

        int x = (Console.WindowWidth - currentWindow[0].Length) / 2;
        int y = 0;
        var count = 0;
        foreach (string line in currentWindow)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(line);
            y++;
            count++;
        }
        Console.WriteLine();
        Console.WriteLine("Width: " + currentWindow[0].Length);
        Console.WriteLine("Height: " + count);
        //100 x 25
    }
}