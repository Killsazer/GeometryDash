namespace Kursach;

using Kursach.Menu;
using Kursach.GameCore;
using System.Text;

class Runner
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        var menu = new StartMenu();
        bool continueCondition = menu.MenuGeneretor();

        while (continueCondition == true)
        {
            var game = new Game();
            continueCondition = game.StartGame();
        }
    }
}