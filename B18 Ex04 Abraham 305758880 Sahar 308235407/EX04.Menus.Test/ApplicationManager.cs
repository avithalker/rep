using EX04.Menus.Interfaces;
using EX04.Menus.Interfaces.MenuItems;
using EX04.Menus.Interfaces.MenuItems.ActionItems;

namespace EX04.Menus.Test
{
    public class ApplicationManager
    {
        public void Run()
        {
            MenuActivator InterfaceMenuActivator = new MenuActivator(BuildMenuWithInterfaceNotificationMode());

            InterfaceMenuActivator.ActiveMenu();
        }

        private SubMenuItem BuildMenuWithInterfaceNotificationMode()
        {
            TimePrinter timePrinterAction = new TimePrinter("Show Time");
            DatePrinter datePrinterAction = new DatePrinter("Show Date");
            CapitalLetterCounter counterAction = new CapitalLetterCounter("Count Capitals");
            VersionPrinter versionAction = new VersionPrinter("Show Version");
            SubMenuItem versionAndCapitalMenu = new SubMenuItem("Version and Capitals");
            SubMenuItem root = new SubMenuItem("Main menu");

            versionAndCapitalMenu.AddNewMenuItem(versionAction);
            versionAndCapitalMenu.AddNewMenuItem(counterAction);
            root.AddNewMenuItem(timePrinterAction);
            root.AddNewMenuItem(datePrinterAction);
            root.AddNewMenuItem(versionAndCapitalMenu);

            return root;
        }
    }
}
