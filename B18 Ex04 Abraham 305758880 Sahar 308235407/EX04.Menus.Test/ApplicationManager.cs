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

            InterfaceMenuActivator.ActiveMenu();
            DelegateMainMenu.Show();
        }

        private Interfaces.MenuItems.SubMenuItem BuildMenuWithInterfaceNotificationMode()
        {
            Interfaces.MenuItems.ActionItems.TimePrinter timePrinterAction = new Interfaces.MenuItems.ActionItems.TimePrinter("Show Time");
            Interfaces.MenuItems.ActionItems.DatePrinter datePrinterAction = new Interfaces.MenuItems.ActionItems.DatePrinter("Show Date");
            Interfaces.MenuItems.ActionItems.CapitalLetterCounter counterAction = new Interfaces.MenuItems.ActionItems.CapitalLetterCounter("Count Capitals");
            Interfaces.MenuItems.ActionItems.VersionPrinter versionAction = new Interfaces.MenuItems.ActionItems.VersionPrinter("Show Version");
            Interfaces.MenuItems.SubMenuItem dateAndTimeMenu = new Interfaces.MenuItems.SubMenuItem("Show Date/Time");
            Interfaces.MenuItems.SubMenuItem versionAndCapitalMenu = new Interfaces.MenuItems.SubMenuItem("Version and Capitals");
            Interfaces.MenuItems.SubMenuItem root = new Interfaces.MenuItems.SubMenuItem("Main menu with interface mode");

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
