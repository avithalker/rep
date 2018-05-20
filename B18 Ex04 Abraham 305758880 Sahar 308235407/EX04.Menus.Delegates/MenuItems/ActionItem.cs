using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX04.Menus.Delegates.MenuItems
{
    public abstract class ActionItem : MenuItem
    {
        public ActionItem(string i_Title) : base(i_Title)
        {
        }

        public abstract void DoAction();
       
        public override void HandleMenuItem()
        {
            this.DoAction();
            BackItem.SetIwasChosenEvent();
        } 
    }
}
