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
        }
        
        public char GetPlayerSign()
        {
            char k_sign;

            if(m_Title == PlayerTitles.ePlayerTitles.PlayerOne)
            {
                k_sign = 'O'; 
            }

            else
            {
                k_sign = 'X';
            }

            return k_sign;
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
