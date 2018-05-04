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
        private PlayerTitles.ePlayerTitles m_Title;
        private PlayerTypes.ePlayerTypes m_Type;
        private String m_Name;
        private char m_PlayerSign;

        public Player(PlayerConfiguration i_playerConfiguration, PlayerTitles.ePlayerTitles i_title)
        {
            m_Score = 0;
            m_Soldiers = new List<Soldier>();
            m_Title = i_title;
            m_Type = i_playerConfiguration.PlayerType;
            m_Name = i_playerConfiguration.PlayerName;
            if(i_title == PlayerTitles.ePlayerTitles.PlayerOne)
            {
                m_PlayerSign = 'O';
            }
            else
            {
                m_PlayerSign = 'X';
            }
        }

        public List<Soldier> Soldiers
        {
            get { return m_Soldiers; }
            set { m_Soldiers = value; }
        }
        
        public char PlayerSign
        {
            get{ return m_PlayerSign; }
            set { m_PlayerSign = value; }
        }

        public PlayerTypes.ePlayerTypes PlayerType
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        public PlayerTitles.ePlayerTitles PlayerTitle
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
            set { m_Score = value; }
        }

        public void AddSoldier(Soldier i_soldier)
        {
            m_Soldiers.Add(i_soldier);
        }
    }
}
