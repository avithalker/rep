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
        private eSoldierTypes m_Type;
        private Location m_Location;
        private ePlayerTitles m_Owner;

        public Soldier(Location i_Location, eSoldierTypes i_Type, ePlayerTitles i_PlayerTitle)
        {
            m_Type = i_Type;
            m_Location = i_Location;
            m_Owner = i_PlayerTitle;
        }

        public eSoldierTypes SoldierType
        {
            get { return m_Type; }
        }

        public ePlayerTitles Owner
        {
            get { return m_Owner; }
        }

        public Location Location
        {
            get { return m_Location; }
            set { m_Location = value; }
        }

        public void PromoteSoldier()
        {
            m_Type = eSoldierTypes.King;
        }
    }
}
