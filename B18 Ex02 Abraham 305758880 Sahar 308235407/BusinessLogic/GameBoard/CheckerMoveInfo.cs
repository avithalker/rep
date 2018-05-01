using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.GameBoard
{
    public class CheckerMoveInfo
    {
        private string m_PlayerName;
        private string m_PreviousCell;
        private string m_CurrentCell;

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

        public CheckerMoveInfo(String i_Action)
        {
            
        }
    }
}
