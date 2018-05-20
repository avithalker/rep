using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX04.Menus.Delegates.MenuItems
{
    public class MainMenu : SubMenuItem
    {
        public MainMenu(string i_Title) : base(i_Title)
        {
            this.m_BackItemUniqueTitle = "Exit";
        }

        public void Show()
        {
            this.HandleMenuItem();
        }
    }
}
