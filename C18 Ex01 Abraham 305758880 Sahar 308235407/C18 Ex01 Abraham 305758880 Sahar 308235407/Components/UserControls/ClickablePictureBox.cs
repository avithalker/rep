using System;
using System.Windows.Forms;

namespace DesktopFacebook.Components.UserControls
{
    public class ClickablePictureBox : PictureBox
    {
        public ClickablePictureBox()
        {
            MouseMove += ClickablePictureBox_MouseMove;
            MouseLeave += ClickablePictureBox_MouseLeave;
        }

        private void ClickablePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void ClickablePictureBox_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }
    }
}
