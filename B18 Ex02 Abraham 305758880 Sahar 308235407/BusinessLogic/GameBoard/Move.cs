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


        public Move(Location i_CurrentLocation, Location i_NextLocation)
        {
            m_CurrentLocation = i_CurrentLocation;
            m_NextLocation = i_NextLocation;
        }

        public Move()
        {
        }

        public static Move Parse(String i_Action)
        {
            Move k_move = new Move();
            String[] k_Locations = i_Action.Split('>');
            if(k_Locations.Length != 2)
            {
                k_move = null; 
            }
            else
            {
                k_move.CurrentLocation = Location.Parse(k_Locations[0]);
                k_move.NextLocation = Location.Parse(k_Locations[1]);

                if (k_move.CurrentLocation == null || k_move.NextLocation == null)
                {
                    k_move = null;
                }
            }

            return k_move;
        }

    }
}
