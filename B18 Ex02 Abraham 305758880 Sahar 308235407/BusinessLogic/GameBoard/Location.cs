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

        public int Row { get { return m_Row; } set { m_Row = value; } }
        public int Col { get { return m_Column; } set { m_Column = value; } }

        public static Location Parse(String i_Location)
        {
            return new Location(i_Location[0] - 'A', i_Location[1] - 'a');
        }
            
    }
}
