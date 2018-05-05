using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Enums;
using BusinessLogic.Configuration;

namespace BusinessLogic
{
    public class Player
    {
        private int m_Score;
        private List<Soldier> m_Soldiers;
        private ePlayerTitles m_Title;
        private ePlayerTypes m_Type;
        private String m_Name;
        private char m_PlayerSign;

        public Player(PlayerConfiguration i_playerConfiguration, ePlayerTitles i_title)
        {
            m_Score = 0;
            m_Soldiers = new List<Soldier>();
            m_Title = i_title;
            m_Type = i_playerConfiguration.PlayerType;
            m_Name = i_playerConfiguration.PlayerName;
            m_PlayerSign = GlobalDefines.GetSoldierSign(i_title, eSoldierTypes.Regular);
        }

        public List<Soldier> Soldiers
        {
            get { return m_Soldiers; }
            set { m_Soldiers = value; }
        }
        
        public void RemoveSoldierFromList(Soldier i_Soldier)
        {
            m_Soldiers.Remove(i_Soldier);
        }

        public char PlayerSign
        {
            get{ return m_PlayerSign; }
            set { m_PlayerSign = value; }
        }

        public ePlayerTypes PlayerType
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        public ePlayerTitles PlayerTitle
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public string PlayerName
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public int Score
        {
            get { return m_Score; }
        }

        public void AddSoldier(Soldier i_soldier)
        {
            m_Soldiers.Add(i_soldier);
        }

        public bool IsHasAliveSoldiers()
        {
            return m_Soldiers.Count != 0;
        }

        public void AddPoints(int i_Points)
        {
            m_Score += i_Points;
        }

    }
}
