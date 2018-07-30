using System;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using DesktopFacebook.Business;
using DesktopFacebook.Components.UserControls;

namespace DesktopFacebook.Components.Pages
{
    public partial class FriendsPage : UserControl
    {
        private FacebookUserManager m_FacebookUserManager;
        private DataFetchIndicator m_DataFetchIndicator;

        public FriendsPage(FacebookUserManager i_FacebookUserManager, DataFetchIndicator i_DataFetchIndicator)
        {
            InitializeComponent();
            m_FacebookUserManager = i_FacebookUserManager;
            m_DataFetchIndicator = i_DataFetchIndicator;
        }

        public void FetchUsersFriends()
        {
            int x = 0;
            int y = 0;
            int lastPicturewidth = 0;
            int lastHeight = 0;

            foreach (User friend in m_FacebookUserManager.NativeClient.Friends)
            {
                addFriendComponent(friend, x, y, ref lastPicturewidth, ref lastHeight);
                updateLocation(ref x, ref y, lastPicturewidth, lastHeight);
            }

            m_DataFetchIndicator.AreFriendsWereFetch = true;
        }

        private void addFriendComponent(User i_friend, int i_x, int i_y, ref int io_lastPictureWidth, ref int io_LastHeight)
        {
            ClickablePictureBox friendsPicture = new ClickablePictureBox();
            friendsPicture.Size = new Size(100, 100);
            friendsPicture.Name = i_friend.Id;
            Label friendsName = new Label();
            friendsPicture.LoadAsync(i_friend.PictureNormalURL);
            friendsPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            friendsPicture.Location = new Point(i_x, i_y);
            friendsName.Text = i_friend.FirstName + " " + i_friend.LastName;
            friendsName.Location = new Point(i_x, i_y + friendsPicture.ClientSize.Height + 5);
            friendsPicture.Click += FriendsPicture_Click;
            Controls.Add(friendsPicture);
            Controls.Add(friendsName);
            io_lastPictureWidth = friendsPicture.ClientSize.Width;
            io_LastHeight = friendsPicture.ClientSize.Height + friendsName.Size.Height;
        }

        private void updateLocation(ref int io_x, ref int io_y, int i_lastPictureWidth, int i_lastHeight)
        {
            io_x += i_lastPictureWidth + 20;

            if (Width - i_lastPictureWidth - 20 <= io_x)
            {
                io_x = 0;
                io_y += i_lastHeight + 20;
            }
        }

        private void FriendsPicture_Click(object sender, EventArgs e)
        {
            PictureBox friendPrictureBox = sender as PictureBox;
            string friendId = friendPrictureBox.Name;
            User friend = m_FacebookUserManager.FindFriendById(friendId);
            if (string.IsNullOrEmpty(friend.Link))
            {
                MessageBox.Show(string.Format("Sorry, the facebook page of {0} is not avilabe right now.", friend.Name));
            }
            else
            {
                System.Diagnostics.Process.Start(friend.Link);
            }
        }
    }
}
