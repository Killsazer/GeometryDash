namespace GeometryDash;

using Kursach.Menu;
using Kursach.GameCore;

class Runner
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // var menu = new StartMenu();
        // bool continueCondition = menu.MenuGeneretor();

        // if (continueCondition == true)
        // {
        //     var game = new Game();
        //     game.StartGame();
        // }

        var game = new Game();
        game.StartGame();
    }
}