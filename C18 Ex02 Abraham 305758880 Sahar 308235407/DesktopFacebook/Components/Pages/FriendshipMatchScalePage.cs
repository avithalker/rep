using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using DesktopFacebook.CustomFeatures.FriendshipMatchScale;

namespace DesktopFacebook.Components.Pages
{
    public partial class FriendshipMatchScalePage : UserControl
    {
        private CacheFriendshipCalculator m_FriendshipMatchScaleCalculator;

        public FriendshipMatchScalePage(User i_facebookUser)
        {
            InitializeComponent();
            m_FriendshipMatchScaleCalculator = new CacheFriendshipCalculator(i_facebookUser);
        }

        public void FetchFriendsToListBox(User i_facebookUser)
        {
            FriendsListBox.DisplayMember = "Name";
            foreach (User friend in i_facebookUser.Friends)
            {
                FriendsListBox.Items.Add(friend);
            }
        }

        private void FriendshipMatchButton_Click(object sender, EventArgs e)
        {
            string valueInPercents;

            if (FriendsListBox.SelectedItem == null)
            {
                MessageBox.Show("Please choose a friend from the list");
            }
            else
            {
                try
                {
                    valueInPercents = m_FriendshipMatchScaleCalculator.Calculate((User)FriendsListBox.SelectedItem).ToString() + '%';
                    FriendshipMatchValue.Text = valueInPercents;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Failed to calculate. Info: {0}", ex.Message));
                }

            }
        }
    }
}
