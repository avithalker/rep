using System;
using EX04.Menus.Interfaces.MenuItems;

namespace EX04.Menus.Test.InterfaceActions
{
    public class TimePrinter : IActionObserver
    {
        public void DoAction()
        {
            Console.WriteLine(DateTime.Now.TimeOfDay.ToString());
        }
    }
}
