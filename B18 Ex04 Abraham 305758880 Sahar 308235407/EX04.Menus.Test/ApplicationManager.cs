using System;
using EX04.Menus.Interfaces;
using EX04.Menus.Delegates.MenuItems;

namespace EX04.Menus.Test
{
    public class ApplicationManager
    {
        public void Run()
        {
            MenuActivator InterfaceMenuActivator = new MenuActivator(BuildMenuWithInterfaceNotificationMode());
            MainMenu DelegateMainMenu = BuildMenuWithDelegateNotificationMode(); ////by delegates

            Console.WriteLine("Starting first menu (inteface mode)");
            InterfaceMenuActivator.ActiveMenu();
            Console.WriteLine("Starting second menu (delegate mode)");
            DelegateMainMenu.Show();
        }

        private Interfaces.MenuItems.SubMenuItem BuildMenuWithInterfaceNotificationMode()
        {
            InterfaceActions.InterfaceActionManager actionManager = new InterfaceActions.InterfaceActionManager();
            Interfaces.MenuItems.ActionItem timePrinterAction = new Interfaces.MenuItems.ActionItem("Show Time");
            Interfaces.MenuItems.ActionItem datePrinterAction = new Interfaces.MenuItems.ActionItem("Show Date");
            Interfaces.MenuItems.ActionItem counterAction = new Interfaces.MenuItems.ActionItem("Count Capitals");
            Interfaces.MenuItems.ActionItem versionAction = new Interfaces.MenuItems.ActionItem("Show Version");
            Interfaces.MenuItems.SubMenuItem dateAndTimeMenu = new Interfaces.MenuItems.SubMenuItem("Show Date/Time");
            Interfaces.MenuItems.SubMenuItem versionAndCapitalMenu = new Interfaces.MenuItems.SubMenuItem("Version and Capitals");
            Interfaces.MenuItems.SubMenuItem root = new Interfaces.MenuItems.SubMenuItem("Main menu with interface mode");

            datePrinterAction.AddNewObserver(actionManager.DatePrinter);
            timePrinterAction.AddNewObserver(actionManager.TimePrinter);
            versionAction.AddNewObserver(actionManager.VersionPrinter);
            counterAction.AddNewObserver(actionManager.CapitalLetterCounter);
            versionAndCapitalMenu.AddNewMenuItem(counterAction);
            versionAndCapitalMenu.AddNewMenuItem(versionAction);
            dateAndTimeMenu.AddNewMenuItem(timePrinterAction);
            dateAndTimeMenu.AddNewMenuItem(datePrinterAction);
            root.AddNewMenuItem(dateAndTimeMenu);
            root.AddNewMenuItem(versionAndCapitalMenu);

            return root;
        }

        private MainMenu BuildMenuWithDelegateNotificationMode()
        {
            MainMenu mainMenu = new MainMenu("Main Menu with delegates mode");
            SubMenuItem dateAndTimeMenu = new SubMenuItem("Show Date/Time");
            SubMenuItem versionsAndCapitalsMenu = new SubMenuItem("Versions and Capitals");
            TimePrinter timeAction = new TimePrinter("Show Time");
            DatePrinter dateAction = new DatePrinter("Show Date");
            CapitalLetterCounter capitalLetterCounterAction = new CapitalLetterCounter("Count Capitals");
            VersionPrinter versionPrinterAction = new VersionPrinter("Show Version");

            dateAndTimeMenu.AddMenuItem(timeAction);
            dateAndTimeMenu.AddMenuItem(dateAction);
            versionsAndCapitalsMenu.AddMenuItem(capitalLetterCounterAction);
            versionsAndCapitalsMenu.AddMenuItem(versionPrinterAction);
            mainMenu.AddMenuItem(dateAndTimeMenu);
            mainMenu.AddMenuItem(versionsAndCapitalsMenu);

            return mainMenu;
        }
    }
}
