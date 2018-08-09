using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DesktopFacebook.Business;
using DesktopFacebook.CommonDefines;
using DesktopFacebook.Components.Pages;
using DesktopFacebook.Components.UserControls;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.Forms
{
    public partial class UserProfileForm : Form
    {
        private FacebookUserManager m_UserManager;
        private DataFetchIndicator m_DataFetchIndicator;
        private CheckinPage m_checkinPage;
        private FriendsPage m_FriendsPage;
        private AlbumsPage m_AlbumPage;
        private SmartPostPage m_SmartPostPage;
        private FriendshipMatchScalePage m_FriendshipMatchScalePage;

        public UserProfileForm(FacebookUserManager i_UserManager)
        {
            InitializeComponent();
            m_UserManager = i_UserManager;
            m_DataFetchIndicator = new DataFetchIndicator();
            addTabsPages();
            initializeUserGeneralInfo();
        }

        private void addTabsPages()
        {
            m_checkinPage = new CheckinPage(m_UserManager, m_DataFetchIndicator);
            m_FriendsPage = new FriendsPage(m_UserManager, m_DataFetchIndicator);
            m_AlbumPage = new AlbumsPage(m_UserManager, m_DataFetchIndicator);
            m_SmartPostPage = new SmartPostPage(m_UserManager);
            m_FriendshipMatchScalePage = new FriendshipMatchScalePage(m_UserManager.NativeClient);
            EventsTab.Controls.Add(new EventsPage(m_UserManager));
            CheckInsTab.Controls.Add(m_checkinPage);
            FriendsTab.Controls.Add(m_FriendsPage);
            AlbumsTab.Controls.Add(m_AlbumPage);
            FriendshipMatchTab.Controls.Add(m_FriendshipMatchScalePage);
            SmartPostTab.Controls.Add(m_SmartPostPage);
        }

        private void initializeUserGeneralInfo()
        {
            UserProfilePicture.LoadAsync(m_UserManager.NativeClient.PictureLargeURL);
            UserNameLabel.Text = m_UserManager.NativeClient.Name;
            UserGenderLabel.Text = m_UserManager.NativeClient.Gender.ToString();
            UsersBirthdate.Text = m_UserManager.NativeClient.Birthday;
            if (m_UserManager.NativeClient.Hometown != null)
            {
                UserHomeTownLabel.Text = m_UserManager.NativeClient.Hometown.Name;
            }

            if (m_UserManager.NativeClient.Location != null)
            {
                UserCurrentCityLabel.Text = m_UserManager.NativeClient.Location.Name;
            }

            if (m_UserManager.NativeClient.RelationshipStatus.HasValue)
            {
                UserRelationshipLabel.Text = m_UserManager.NativeClient.RelationshipStatus.Value.ToString();
            }
        }

        private void fetchUserPostsAsync()
        {
            Thread loadPostThread = new Thread(() => fetchUserPosts());

            loadPostThread.Start();
        }

        private void fetchUserPosts()
        {
            int wallPostXLocation = AttachPhotoPictureBox1.Location.X;
            int wallPostYLocation = AttachPhotoPictureBox1.Location.Y + AttachPhotoPictureBox1.Height + 40;
            WallPostControl wallPostControl;

            foreach (Post wallPost in m_UserManager.NativeClient.WallPosts)
            {
                wallPostControl = AddWallPostComponent(wallPost, wallPostXLocation, wallPostYLocation);
                wallPostYLocation += wallPostControl.Height + 10;
            }

            m_DataFetchIndicator.ArePostsWereFetch = true;
        }

        private WallPostControl AddWallPostComponent(Post i_wallPost, int i_X, int i_Y)
        {
            WallPostControl wallPostControl = new WallPostControl(m_UserManager, i_wallPost);
            wallPostControl.Location = new Point(i_X, i_Y);
            UserWallTab.Invoke(new Action(() => UserWallTab.Controls.Add(wallPostControl)));
            return wallPostControl;
        }

        private void AddNewWallPostToExistWall(Post i_wallPost, int i_X, int i_Y)
        {
            bool isFirstWallPost = true;
            int marginTop = 10;

            foreach (Control control in UserWallTab.Controls)
            {
                if (!isFirstWallPost)
                {
                    marginTop = 0;
                }

                if (control is WallPostControl)
                {
                    control.Location = new Point(control.Location.X, control.Location.Y + control.Height + marginTop);
                    isFirstWallPost = false;
                }
            }

            AddWallPostComponent(i_wallPost, i_X, i_Y);
        }

        private void PostButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (PreviewPhotoPictureBox.Image == null)
                {
                    int wallPostXLocation = AttachPhotoPictureBox1.Location.X;
                    int wallPostYLocation = AttachPhotoPictureBox1.Location.Y + AttachPhotoPictureBox1.Height + 40;
                    Status postedStatus = m_UserManager.NativeClient.PostStatus(PostTextBox.Text);
                    AddNewWallPostToExistWall(m_UserManager.NativeClient.Posts[0], wallPostXLocation, wallPostYLocation);
                }
                else
                {
                    m_UserManager.NativeClient.PostPhoto(PreviewPhotoPictureBox.ImageLocation, PostTextBox.Text);
                }

                CleanPostControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Post Action Failed: " + ex.Message);
            }
        }

        private void PostTextBox_MouseEnter(object sender, EventArgs e)
        {
            RichTextBox postRichTextBox = sender as RichTextBox;

            if (string.Compare(postRichTextBox.Text, "What's on your mind?") == 0)
            {
                postRichTextBox.Text = string.Empty;
                postRichTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void PostTextBox_MouseLeave(object sender, EventArgs e)
        {
            RichTextBox postRichTextBox = sender as RichTextBox;
            if (string.IsNullOrEmpty(postRichTextBox.Text))
            {
                postRichTextBox.Text = "What's on your mind?";
                postRichTextBox.ForeColor = SystemColors.GrayText;
            }
        }

        private void CleanPostControls()
        {
            PreviewPhotoPictureBox.Image = null;
            PostTextBox.Clear();
            ClearImagePictureBox1.Hide();
        }

        private void AttachPhotoPictureBox1_Click(object sender, EventArgs e)
        {
            if (PictureFileDialog.ShowDialog() == DialogResult.OK)
            {
                PreviewPhotoPictureBox.Load(PictureFileDialog.FileName);
                ClearImagePictureBox1.Show();
            }

            PictureFileDialog.FileName = string.Empty;
        }

        private void ClearImagePictureBox1_Click(object sender, EventArgs e)
        {
            PreviewPhotoPictureBox.Image = null;
            ClearImagePictureBox1.Hide();
        }

        private void UsersDetailsControlTab_Selected(object sender, TabControlEventArgs e)
        {
            FetchRelevantData();
        }

        private void UserProfileForm_Shown(object sender, EventArgs e)
        {
            FetchRelevantData();
        }

        private void FetchRelevantData()
        {
            switch (UsersDetailsControlTab.SelectedIndex)
            {
                case (int)eTabPageType.WallPage:
                    {
                        if (!m_DataFetchIndicator.ArePostsWereFetch)
                        {
                            fetchUserPostsAsync();
                        }

                        break;
                    }

                case (int)eTabPageType.FriendsPage:
                    {
                        if (!m_DataFetchIndicator.AreFriendsWereFetch)
                        {
                            m_FriendsPage.FetchUsersFriends();
                        }

                        break;
                    }

                case (int)eTabPageType.AlbumPage:
                    {
                        if (!m_DataFetchIndicator.AreAlbumsWereFetch)
                        {
                            m_AlbumPage.FetchUserAlbums();
                        }

                        break;
                    }

                case (int)eTabPageType.CheckinPage:
                    {
                        if (!m_DataFetchIndicator.AreCheckinWereFetch)
                        {
                            m_checkinPage.FetchCheckins();
                        }

                        break;
                    }

                case (int)eTabPageType.FriendshipMatchScalePage:
                    {
                        if (!m_DataFetchIndicator.AreFriendsInFriendshipMatcTabWereFetch)
                        {
                            m_FriendshipMatchScalePage.FetchFriendsToListBox(m_UserManager.NativeClient);
                            m_DataFetchIndicator.AreFriendsInFriendshipMatcTabWereFetch = true;
                        }

                        break;
                    }
            }
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            m_UserManager.Logout();
            Close();
        }
    }
}
