using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using DesktopFacebook.CustomFeatures.FriendshipMatchScale;

namespace DesktopFacebook.Components.Pages
{
    public partial class FriendshipMatchScalePage : UserControl
    {
        FriendshipMatchScaleCalculator m_FriendshipMatchScaleCalculator;

        public FriendshipMatchScalePage(User i_facebookUser)
        {
            InitializeComponent();
            m_FriendshipMatchScaleCalculator = new FriendshipMatchScaleCalculator(i_facebookUser);
        }

        public void FetchFriendsToChecklist(User i_facebookUser)
        {
            string friendsFullName;

            foreach (User friend in i_facebookUser.Friends)
            {
                friendsFullName = friend.FirstName + " " + friend.LastName;
                FriendsListBox.Items.Add(friendsFullName);
            }
        }

        public void FriendsListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < FriendsListBox.Items.Count; i++)
                if (i != e.Index) FriendsListBox.SetItemChecked(i, false);
        }
    }

   
}
