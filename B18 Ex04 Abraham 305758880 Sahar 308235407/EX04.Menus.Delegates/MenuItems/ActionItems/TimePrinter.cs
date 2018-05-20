using System;

namespace EX04.Menus.Delegates.MenuItems
{
    public class TimePrinter : ActionItem
    {
        public TimePrinter(string i_Title) : base(i_Title)
        {
        }

        public override void DoAction()
        {
            Console.WriteLine(DateTime.Now.TimeOfDay.ToString());
        }
    }
}
