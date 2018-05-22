using System.Collections.Generic;

namespace EX04.Menus.Interfaces.MenuItems
{
    public class ActionItem : MenuItem
    {
        private List<IActionObserver> m_ActionObservers;

        public ActionItem(string i_Title) : base(i_Title)
        {
            m_ActionObservers = new List<IActionObserver>();
        }

        public void AddNewObserver(IActionObserver i_Observer)
        {
            m_ActionObservers.Add(i_Observer);
        }

        public void RemoveObserver(IActionObserver i_Observer)
        {
            m_ActionObservers.Remove(i_Observer);
        }

        public void HandleActionItem()
        {
            foreach (IActionObserver observer in m_ActionObservers)
            {
                observer.DoAction();
            }
        }
    }
}
