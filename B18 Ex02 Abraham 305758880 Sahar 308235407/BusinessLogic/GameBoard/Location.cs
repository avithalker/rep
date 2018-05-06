using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Location
    {
        private int m_Row;
        private int m_Column;

        public Location(int i_row, int i_col)
        {
            m_Row = i_row;
            m_Column = i_col;
        }

        public int Row
        {
            get { return m_Row; }
            set { m_Row = value; }
        }

        public int Col
        {
            get { return m_Column; }
            set { m_Column = value; }
        }

        public static Location Parse(string i_Location)
        {
            Location location;

            if ((i_Location[0] < 'A' || i_Location[0] > 'Z') || (i_Location[1] < 'a' || i_Location[1] > 'z'))
            {
                location = null;
            }
            else
            {
                location = new Location(i_Location[1] - 'a', i_Location[0] - 'A');
            }

            return location;
        }

        public bool AreEqual(Location i_Location)
        {
            return m_Row == i_Location.Row && m_Column == i_Location.Col;
        }

        public override string ToString()
        {
            char col = (char)(m_Column + 'A');
            char row = (char)(m_Row + 'a');
            return col.ToString() + row.ToString();
        }
    }
}
