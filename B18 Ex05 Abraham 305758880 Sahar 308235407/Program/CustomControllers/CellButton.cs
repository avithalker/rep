using System.Windows.Forms;

namespace Program.CustomControllers
{
    public class CellButton : Button
    {
        private int m_RowIndex;
        private int m_ColumnIndex;

        public int ColumnIndex
        {
            get { return m_ColumnIndex; }
            set { m_ColumnIndex = value; }
        }

        public int RowIndex
        {
            get { return m_RowIndex; }
            set { m_RowIndex = value; }
        }

        public CellButton(int i_RowIndex, int i_ColumnIndex)
        {
            m_RowIndex = i_RowIndex;
            m_ColumnIndex = i_ColumnIndex;
        }
    }
}
