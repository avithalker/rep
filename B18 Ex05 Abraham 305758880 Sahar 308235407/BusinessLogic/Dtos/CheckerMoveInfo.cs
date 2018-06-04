namespace BusinessLogic.Dtos
{
    public class CheckerMoveInfo
    {
        private string m_PlayerName;
        private string m_PreviousCell;
        private string m_CurrentCell;

        public CheckerMoveInfo(string i_PlayerName, string i_PreviousCell, string i_CurrentCell)
        {
            m_PlayerName = i_PlayerName;
            m_CurrentCell = i_CurrentCell;
            m_PreviousCell = i_PreviousCell;
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
