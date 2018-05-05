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

        public Soldier(Location location, eSoldierTypes i_type, ePlayerTitles i_playerTitle)
        {
            m_Type = i_type;
            m_Location = location;
            m_Owner = i_playerTitle;
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
