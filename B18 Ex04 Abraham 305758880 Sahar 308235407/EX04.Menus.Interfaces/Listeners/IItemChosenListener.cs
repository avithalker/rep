using EX04.Menus.Interfaces.MenuItems;

namespace EX04.Menus.Interfaces.Listeners
{
    internal interface IItemChosenListener
    {
        void NotifyChosenItem(MenuItem i_ChosenItem);
    }
}
