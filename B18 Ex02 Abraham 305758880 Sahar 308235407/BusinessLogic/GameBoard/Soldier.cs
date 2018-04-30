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
        private PlayerTitles.ePlayerTitles m_PlayersTitle;

        public Soldier(Location location, SoldierTypes.eSoldierTypes i_type,PlayerTitles.ePlayerTitles i_playerTitle)
        {
            this.m_Type = i_type;
            this.m_Location = location;
        }

    }

}
