namespace EX04.Menus.Delegates.MenuItems
{
    public abstract class ActionItem : MenuItem
    {
        public ActionItem(string i_Title) : base(i_Title)
        {
        }

        public abstract void DoAction();
       
        public override void HandleMenuItem()
        {
            DoAction();
            BackItem.OnItemWasChosen();
        } 
    }
}
