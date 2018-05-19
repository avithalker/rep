namespace EX04.Menus.Interfaces.MenuItems
{
    public abstract class MenuItem
    {
        protected string m_Title;

        public string Title
        {
            get { return m_Title; }
        }

        public MenuItem(string i_Title)
        {
            m_Title = i_Title;
        }

        public abstract void HandleItem();
    }
}
