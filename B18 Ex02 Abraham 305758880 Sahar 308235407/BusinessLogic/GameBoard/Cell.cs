namespace BusinessLogic.GameBoard
{
    public class Cell
    {
        private Soldier m_Soldier = null;
        private bool m_IsEnabled;

        public bool IsEnabled
        {
            get { return m_IsEnabled; }
            set { m_IsEnabled = value; }
        }

        public Soldier Soldier
        {
            get { return m_Soldier; }
            set { m_Soldier = value; }
        }

        public Cell(Soldier i_soldier)
        {
            m_Soldier = i_soldier;
        }

        public Cell()
        { 
        }

        public bool IsCellEmpty()
        {
            return m_Soldier == null;
        }
    }
}
