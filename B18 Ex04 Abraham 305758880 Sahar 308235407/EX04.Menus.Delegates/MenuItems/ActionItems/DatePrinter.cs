using System;

namespace EX04.Menus.Delegates.MenuItems
{
    public class DatePrinter : ActionItem
    {
        public DatePrinter(string i_Title) : base(i_Title)
        {
        }

        public override void DoAction()
        {
            Console.WriteLine(DateTime.Now.Date.ToString("dd.MM.yyyy"));
        }
    }
}
