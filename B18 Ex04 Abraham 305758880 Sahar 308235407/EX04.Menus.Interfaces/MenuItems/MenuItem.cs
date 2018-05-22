namespace EX04.Menus.Interfaces.MenuItems
{
    public abstract class MenuItem
    {
        protected string m_Title;
        protected MenuItem m_BackItem;

        public string Title
        {
            get { return m_Title; }
        }

        public MenuItem BackItem
        {
            get { return m_BackItem; }
            set { m_BackItem = value; }
        }

        public MenuItem(string i_Title)
        {
            m_Title = i_Title;
        }
    }
}
