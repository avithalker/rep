using EX04.Menus.Interfaces;
using EX04.Menus.Interfaces.MenuItems;
using EX04.Menus.Interfaces.MenuItems.ActionItems;
using EX04.Menus.Delegates.MenuItems;

namespace EX04.Menus.Test
{
    public class ApplicationManager
    {
        public void Run()
        {
            MenuActivator InterfaceMenuActivator = new MenuActivator(BuildMenuWithInterfaceNotificationMode());
            MainMenu DelegateMainMenu = BuildMenuWithDelegateNotificationMode(); ////by delegates

            InterfaceMenuActivator.ActiveMenu();
            DelegateMainMenu.Show();
        }

        private Interfaces.MenuItems.SubMenuItem BuildMenuWithInterfaceNotificationMode()
        {
            Interfaces.MenuItems.ActionItems.TimePrinter timePrinterAction = new Interfaces.MenuItems.ActionItems.TimePrinter("Show Time");
            Interfaces.MenuItems.ActionItems.DatePrinter datePrinterAction = new Interfaces.MenuItems.ActionItems.DatePrinter("Show Date");
            Interfaces.MenuItems.ActionItems.CapitalLetterCounter counterAction = new Interfaces.MenuItems.ActionItems.CapitalLetterCounter("Count Capitals");
            Interfaces.MenuItems.ActionItems.VersionPrinter versionAction = new Interfaces.MenuItems.ActionItems.VersionPrinter("Show Version");
            Interfaces.MenuItems.SubMenuItem versionAndCapitalMenu = new Interfaces.MenuItems.SubMenuItem("Version and Capitals");
            Interfaces.MenuItems.SubMenuItem root = new Interfaces.MenuItems.SubMenuItem("Main menu");

            versionAndCapitalMenu.AddNewMenuItem(versionAction);
            versionAndCapitalMenu.AddNewMenuItem(counterAction);
            root.AddNewMenuItem(timePrinterAction);
            root.AddNewMenuItem(datePrinterAction);
            root.AddNewMenuItem(versionAndCapitalMenu);

            return root;
        }

        private MainMenu BuildMenuWithDelegateNotificationMode()
        {
            MainMenu mainMenu = new MainMenu("Main Menu");
            Delegates.MenuItems.SubMenuItem dateAndTimeMenu = new Delegates.MenuItems.SubMenuItem("Show Date/Time");
            Delegates.MenuItems.SubMenuItem versionsAndCapitalsMenu = new Delegates.MenuItems.SubMenuItem("Versions and Capitals");
            Delegates.MenuItems.TimePrinter timeAction = new Delegates.MenuItems.TimePrinter("Show Time");
            Delegates.MenuItems.DatePrinter dateAction = new Delegates.MenuItems.DatePrinter("Show Date");
            Delegates.MenuItems.CapitalLetterCounter capitalLetterCounterAction = new Delegates.MenuItems.CapitalLetterCounter("Count Capitals");
            Delegates.MenuItems.VersionPrinter versionPrinterAction = new Delegates.MenuItems.VersionPrinter("Show Version");

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
