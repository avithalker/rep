﻿using BusinessLogic.Enums;

namespace BusinessLogic.Dtos
{
    public class PlayerInfo
    {
        private string m_PlayerName;
        private PlayerTypes m_PlayerType;
        private PlayerTitles m_PlayerTitle;
        private char m_PlayerSign;

        public char PlayerSign
        {
            get { return m_PlayerSign; }
            set { m_PlayerSign = value; }
        }

        public PlayerTitles PlayerTitle
        {
            get { return m_PlayerTitle; }
            set { m_PlayerTitle = value; }
        }

        public string PlayerName
        {
            get { return m_PlayerName; }
            set { m_PlayerName = value; }
        }

        public PlayerTypes PlayerType
        {
            get { return m_PlayerType; }
            set { m_PlayerType = value; }
        }
    }
}
