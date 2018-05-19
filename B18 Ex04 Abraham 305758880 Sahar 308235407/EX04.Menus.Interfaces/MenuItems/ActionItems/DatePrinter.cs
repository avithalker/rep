using System;

namespace EX04.Menus.Interfaces.MenuItems.ActionItems
{
    public class DatePrinter : MenuItem
    {
        public DatePrinter(string i_Title) : base(i_Title)
        {
        }

        public override void HandleItem()
        {
            Console.WriteLine(DateTime.Now.Date.ToString("dd.MM.yyyy"));
        }
    }
}
