using System;
using EX04.Menus.Interfaces.MenuItems;

namespace EX04.Menus.Test.InterfaceActions
{
    public class DatePrinter : IActionObserver
    {
        public void DoAction()
        {
            Console.WriteLine(DateTime.Now.Date.ToString("dd.MM.yyyy"));
        }
    }
}
