using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Enums;
using BusinessLogic.GameBoard;

namespace BusinessLogic
{
    public class Soldier
    {
        private SoldierTypes.eSoldierTypes m_Type;
        private Location m_Location;
        private PlayerTitles.ePlayerTitles m_Owner;

        public Soldier(Location location, SoldierTypes.eSoldierTypes i_type, PlayerTitles.ePlayerTitles i_playerTitle)
        {
            this.m_Type = i_type;
            this.m_Location = location;
            m_Owner = i_playerTitle;
        }

        public SoldierTypes.eSoldierTypes SoldierType
        {
            get { return m_Type; }
        }

        public PlayerTitles.ePlayerTitles Owner
        {
            get { return m_Owner; }
        }
    }
}
