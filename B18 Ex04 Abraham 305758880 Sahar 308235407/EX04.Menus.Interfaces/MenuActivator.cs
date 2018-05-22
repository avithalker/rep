using System;
using EX04.Menus.Interfaces.MenuItems;

namespace EX04.Menus.Interfaces
{
    public class MenuActivator
    {
        private SubMenuItem m_MenuRoot;
        private MenuItem m_CurrentItem;
        private SubMenuItem m_ExitItem;
        private bool m_IsMenuRuning;

        public MenuActivator(SubMenuItem i_MenuRoot)
        {
            m_MenuRoot = i_MenuRoot;
            setExitItem();
        }

        public void ActiveMenu()
        {
            m_CurrentItem = m_MenuRoot;
            m_IsMenuRuning = true;

            while (m_IsMenuRuning)
            {
                if(m_CurrentItem is SubMenuItem)
                {
                    SubMenuItem subMenu = m_CurrentItem as SubMenuItem;
                    MenuItem userMenuChoice = subMenu.HandleSubMenuItem();

                    m_CurrentItem = userMenuChoice;
                    if(m_CurrentItem == m_ExitItem)
                    {
                        exitMenu();
                    }
                }
                else
                {
                    ActionItem actionItem = m_CurrentItem as ActionItem;

                    Console.Clear();
                    actionItem.HandleActionItem();
                    m_CurrentItem = actionItem.BackItem;
                }
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
    }
}
