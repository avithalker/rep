﻿using System;
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
    }
}
