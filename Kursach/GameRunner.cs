using Kursach.Menu;
using Kursach.GameCore;
using System.Text;

namespace Kursach;

class Runner
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
        var menu = new StartMenu();
        bool continueCondition = menu.MenuGenerator();

        while (continueCondition == true)
        {
            var game = new Game();
            continueCondition = game.StartGame();
        }
        Console.Clear();
        Console.WriteLine("\n Thanks for playing! Press any key to exit...");
        Console.ReadKey(true);
        Console.CursorVisible = true;
    }
}