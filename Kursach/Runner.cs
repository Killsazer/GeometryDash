namespace GeometryDash;

using GeometryDashMenu;
using GeometryDashMap;

class Runner
{
    static void Main()
    {
        var menu = new StartMenu();
        bool continueCondition = menu.MenuGenereator();

        if (continueCondition == true)
        {
            var map = new Map();
            map.MapGenerator();
        }
    }
}