using System;
using System.Collections.Generic;
using EX04.Menus.Interfaces.Listeners;

namespace EX04.Menus.Interfaces.MenuItems
{
    public class SubMenuItem : MenuItem, IItemChosenListener
    {
        private List<MenuItem> m_MenuItems;
        private MenuItem m_BackItem;
        private string m_BackItemUniqueTitle;
        private List<IItemChosenListener> m_ItemChosenListener;

        public SubMenuItem(string i_Title) : base(i_Title)
        {
            m_BackItem = null;
            m_MenuItems = new List<MenuItem>();
            m_ItemChosenListener = new List<IItemChosenListener>();
        }

        public MenuItem BackItem
        {
            get { return m_BackItem; }
            set { m_BackItem = value; }
        }

        public string BackItemUniqueTitle
        {
            get { return m_BackItemUniqueTitle; }
            set { m_BackItemUniqueTitle = value; }
        }

        public List<MenuItem> MenuItems
        {
            get { return m_MenuItems; }
        }

        internal void AddItemListner(IItemChosenListener i_Listener)
        {
            m_ItemChosenListener.Add(i_Listener);
        }

        internal void RemoveItemListner(IItemChosenListener i_Listener)
        {
            m_ItemChosenListener.Remove(i_Listener);
        }

        public void AddNewMenuItem(MenuItem i_menuItem)
        {
            if (i_menuItem is SubMenuItem)
            {
                SubMenuItem subMenuItem = i_menuItem as SubMenuItem;
                subMenuItem.BackItem = this;
                subMenuItem.BackItemUniqueTitle = "Back";
                subMenuItem.AddItemListner(this);
            }

            m_MenuItems.Add(i_menuItem);
        }

        public override void HandleItem()
        {
            MenuItem userChoice;

            showSubMenu();
            userChoice = getUserChoice();
            ((IItemChosenListener)this).NotifyChosenItem(userChoice);
        }

        void IItemChosenListener.NotifyChosenItem(MenuItem i_ChosenItem)
        {
            foreach (IItemChosenListener listener in m_ItemChosenListener)
            {
                listener.NotifyChosenItem(i_ChosenItem);
            }
        }

        private void showSubMenu()
        {
            int choiceIndex = 1;

            Console.WriteLine(string.Format("**** {0} ****", m_Title));
            foreach (MenuItem menuItem in m_MenuItems)
            {
                Console.WriteLine("{0}. {1}", choiceIndex, menuItem.Title);
                choiceIndex++;
            }

            Console.WriteLine("{0}. {1}", 0, m_BackItemUniqueTitle);
        }

        private MenuItem getUserChoice()
        {
            bool isChoiceValid = false;
            int choiceIndex;
            MenuItem chosenItem;

            do
            {
                Console.WriteLine("Please enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out choiceIndex))
                {
                    if (choiceIndex >= 0 && choiceIndex <= m_MenuItems.Count)
                    {
                        isChoiceValid = true;
                    }
                }

                if(!isChoiceValid)
                {
                    Console.WriteLine("Invalid choice. Try again!");
                }
            }
            while (!isChoiceValid);

            chosenItem = getMenuItemByIndex(choiceIndex);
            return chosenItem;
        }

        private MenuItem getMenuItemByIndex(int choiceIndex)
        {
            MenuItem chosenItem;

            if (choiceIndex == 0)
            {
                chosenItem = m_BackItem;
            }
            else
            {
                chosenItem = m_MenuItems[choiceIndex - 1];
            }

            return chosenItem;
        }
    }
}
