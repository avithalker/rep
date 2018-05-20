namespace EX04.Menus.Delegates.MenuItems
{
    public class MainMenu : SubMenuItem
    {
        public MainMenu(string i_Title) : base(i_Title)
        {
            m_BackItemUniqueTitle = "Exit";
        }

        public void Show()
        {
            HandleMenuItem();
        }
    }
}
