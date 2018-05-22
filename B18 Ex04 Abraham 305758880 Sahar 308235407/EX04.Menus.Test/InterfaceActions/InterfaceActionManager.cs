using EX04.Menus.Interfaces.MenuItems;

namespace EX04.Menus.Test.InterfaceActions
{
    public class InterfaceActionManager
    {
        private IActionObserver m_DatePrinter;
        private IActionObserver m_TimePrinter;
        private IActionObserver m_VersionPrinter;
        private IActionObserver m_CapitalLetterCounter;

        public InterfaceActionManager()
        {
            m_DatePrinter = new DatePrinter();
            m_TimePrinter = new TimePrinter();
            m_VersionPrinter = new VersionPrinter();
            m_CapitalLetterCounter = new CapitalLetterCounter();
        }

        public IActionObserver CapitalLetterCounter
        {
            get { return m_CapitalLetterCounter; }
        }

        public IActionObserver VersionPrinter
        {
            get { return m_VersionPrinter; }
        }

        public IActionObserver TimePrinter
        {
            get { return m_TimePrinter; }
        }

        public IActionObserver DatePrinter
        {
            get { return m_DatePrinter; }
        }
    }
}
