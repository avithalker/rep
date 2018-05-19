using System;
using EX04.Menus.Interfaces.Listeners;
using EX04.Menus.Interfaces.MenuItems;

namespace EX04.Menus.Interfaces
{
    public class MenuActivator : IItemChosenListener
    {
        private SubMenuItem m_MenuRoot;
        private MenuItem m_CurrentItem;
        private SubMenuItem m_ExitItem;
        private bool m_IsMenuRuning;

        public MenuActivator(SubMenuItem i_MenuRoot)
        {
            m_MenuRoot = i_MenuRoot;
            m_MenuRoot.AddItemListner(this);
            setExitItem();
        }

        public void ActiveMenu()
        {
            m_CurrentItem = m_MenuRoot;
            m_IsMenuRuning = true;

            while (m_IsMenuRuning)
            {
                m_CurrentItem.HandleItem();
            }
        }

        private void setExitItem()
        {
            m_ExitItem = new SubMenuItem("Exit");
            m_MenuRoot.BackItem = m_ExitItem;
            m_MenuRoot.BackItemUniqueTitle = "Exit";
        }

        private void exitMenu()
        {
            m_IsMenuRuning = false;
        }

        void IItemChosenListener.NotifyChosenItem(MenuItem i_ChosenItem)
        {
            if (i_ChosenItem == m_ExitItem)
            {
                exitMenu();
            }
            else if (i_ChosenItem is SubMenuItem)
            {
                Console.Clear();
                m_CurrentItem = i_ChosenItem;
            }
            else
            {
                Console.Clear();
                i_ChosenItem.HandleItem();
            }
        }
    }
}
