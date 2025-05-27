namespace GeometryDash;

using GeometryDashMenu;
using GeometryDashLogicStarter;

class Runner
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var menu = new StartMenu();
        bool continueCondition = menu.MenuGenereator();

        if (continueCondition == true)
        {
            var starter = new Starter();
            starter.StartGame();
        }
    }
}