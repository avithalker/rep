using System;

namespace EX04.Menus.Interfaces.MenuItems
{
    public class VersionPrinter : MenuItem
    {
        public VersionPrinter(string i_Title) : base(i_Title)
        {
        }

        public override void HandleItem()
        {
            Console.WriteLine("Version: 18.2.4.0");
        }
    }
}
