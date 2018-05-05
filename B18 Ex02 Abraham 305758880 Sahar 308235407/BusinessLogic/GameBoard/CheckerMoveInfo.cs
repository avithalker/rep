namespace BusinessLogic.GameBoard
{
    public class CheckerMoveInfo
    {
        private string m_PlayerName;
        private string m_PreviousCell;
        private string m_CurrentCell;

        public CheckerMoveInfo()
        {
           
        }

        public string CurrentCell
        {
            get { return m_CurrentCell; }
            set { m_CurrentCell = value; }
        }

        public string PreviousCell
        {
            get { return m_PreviousCell; }
            set { m_PreviousCell = value; }
        }

        public string PlayerName
        {
            get { return m_PlayerName; }
            set { m_PlayerName = value; }
        }
    }
}
