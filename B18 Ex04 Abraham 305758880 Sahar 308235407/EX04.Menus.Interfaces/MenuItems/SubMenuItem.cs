using System;
using System.Collections.Generic;

namespace EX04.Menus.Interfaces.MenuItems
{
    public class SubMenuItem : MenuItem
    {
        private List<MenuItem> m_MenuItems;
        private string m_BackItemUniqueTitle;

        public SubMenuItem(string i_Title) : base(i_Title)
        {
            m_BackItem = null;
            m_MenuItems = new List<MenuItem>();
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

        public void AddNewMenuItem(MenuItem i_menuItem)
        {
            i_menuItem.BackItem = this;
            if (i_menuItem is SubMenuItem)
            {
                SubMenuItem subMenuItem = i_menuItem as SubMenuItem;
                subMenuItem.BackItemUniqueTitle = "Back";
            }

            m_MenuItems.Add(i_menuItem);
        }

        public MenuItem HandleSubMenuItem()
        {
            MenuItem userChoice;

            showSubMenu();
            userChoice = getUserChoice();
            return userChoice;
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
