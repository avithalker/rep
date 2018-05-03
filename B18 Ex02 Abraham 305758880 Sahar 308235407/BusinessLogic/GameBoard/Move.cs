using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.GameBoard
{
    public class Move
    {
        private Location m_CurrentLocation;
        private Location m_NextLocation;

        public Location CurrentLocation { get{ return m_CurrentLocation; } set { m_CurrentLocation = value; } }
        public Location NextLocation { get { return m_NextLocation; } set { m_NextLocation = value; } }

        public Move(String i_CurrentLocation, String i_NextLocation)
        {
            m_CurrentLocation = Location.Parse(i_CurrentLocation);
            m_NextLocation = Location.Parse(i_NextLocation);
        }

    }
}
