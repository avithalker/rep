﻿using System;
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

        public Player(PlayerConfiguration i_playerConfiguration,PlayerTitles.ePlayerTitles i_title)
        {
            m_Score = 0;
            m_Soldiers = new List<Soldier>();
            m_Title = i_title;
            m_Type = i_playerConfiguration.PlayerType;
            m_Name = i_playerConfiguration.PlayerName;

        }
    }
}
