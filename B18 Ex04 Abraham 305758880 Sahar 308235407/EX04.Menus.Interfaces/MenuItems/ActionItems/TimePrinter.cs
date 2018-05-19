using System;

namespace EX04.Menus.Interfaces.MenuItems.ActionItems
{
    public class TimePrinter : MenuItem
    {
        public TimePrinter(string i_Title) : base(i_Title)
        {
        }

        public override void HandleItem()
        {
            Console.WriteLine(DateTime.Now.TimeOfDay.ToString());
        }
    }
}
