using System;
using System.Collections.Generic;
using System.Drawing;
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
        private User m_FacebookUser;
        private DataFetchIndicator m_DataFetchIndicator;
        private CheckinPage m_checkinPage;
        private FriendsPage m_FriendsPage;
        private AlbumsPage m_AlbumPage;


        public UserProfileForm(FacebookUserManager i_UserManager)
        {
            InitializeComponent();
            m_UserManager = i_UserManager;
            m_FacebookUser = m_UserManager.NativeClient;
            m_DataFetchIndicator = new DataFetchIndicator();
            addTabsPages();
            initializeUserGeneralInfo();
        }

        private void addTabsPages()
        {
            m_checkinPage = new CheckinPage(m_UserManager, m_DataFetchIndicator);
            m_FriendsPage = new FriendsPage(m_UserManager, m_DataFetchIndicator);
            m_AlbumPage = new AlbumsPage(m_UserManager, m_DataFetchIndicator);

            EventsTab.Controls.Add(new EventsPage(m_UserManager));
            CheckInsTab.Controls.Add(m_checkinPage);
            FriendsTab.Controls.Add(m_FriendsPage);
            AlbumsTab.Controls.Add(m_AlbumPage);
        }

        private void initializeUserGeneralInfo()
        {
            UserProfilePicture.LoadAsync(m_FacebookUser.PictureLargeURL);
            UserNameLabel.Text = m_FacebookUser.Name;
            UserGenderLabel.Text = m_FacebookUser.Gender.ToString();
            UsersBirthdate.Text = m_FacebookUser.Birthday;
            if (m_FacebookUser.Hometown != null)
            {
                UserHomeTownLabel.Text = m_FacebookUser.Hometown.Name;
            }

            if (m_FacebookUser.Location != null)
            {
                UserCurrentCityLabel.Text = m_FacebookUser.Location.Name;
            }

            if (m_FacebookUser.RelationshipStatus.HasValue)
            {
                UserRelationshipLabel.Text = m_FacebookUser.RelationshipStatus.Value.ToString();
            }
        }

        private void fetchUserPosts()
        {
            int wallPostXLocation = AttachPhotoPictureBox1.Location.X;
            int wallPostYLocation = AttachPhotoPictureBox1.Location.Y + AttachPhotoPictureBox1.Height + 40;
            WallPostControl wallPostControl;

            foreach (Post wallPost in m_FacebookUser.WallPosts)
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
            UserWallTab.Controls.Add(wallPostControl);
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
                    Status postedStatus = m_FacebookUser.PostStatus(PostTextBox.Text);
                    AddNewWallPostToExistWall(m_FacebookUser.Posts[0], wallPostXLocation, wallPostYLocation);
                }
                else
                {
                    m_FacebookUser.PostPhoto(PreviewPhotoPictureBox.ImageLocation, PostTextBox.Text);
                }

                CleanPostControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Post Action Failed: " + ex.Message);
            }
        }

        private void RecentPostsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int counter = 1;

            foreach (Post post in m_FacebookUser.Posts)
            {
                while (counter <= 5)
                {
                    if (post.Message != null)
                    {
                        RecentPostsListBox.Items.Add(post.Message);
                    }
                    else if (post.Caption != null)
                    {
                        RecentPostsListBox.Items.Add(post.Caption);
                    }
                    else
                    {
                        RecentPostsListBox.Items.Add(string.Format("[{0}]", post.Type));
                    }
                }

                counter++;
            }
        }

        private void TopFiveLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FacebookObjectCollection<Post> posts = m_FacebookUser.Posts;
            Post mostPopular;
            for (int i = 0; i < 5; i++)
            {
                mostPopular = getMostPopularPost(posts);
                TopFivePostsListBox.Items.Add(mostPopular);
                posts.Remove(mostPopular);
            }
        }

        private Post getMostPopularPost(FacebookObjectCollection<Post> i_posts)
        {
            Post mostPopular = i_posts[0];

            foreach (Post post in i_posts)
            {
                if (mostPopular.LikedBy.Count < post.LikedBy.Count)
                {
                    mostPopular = post;
                }
            }

            return mostPopular;
        }

        private void PostTextBox_MouseEnter(object sender, EventArgs e)
        {
            RichTextBox postRichTextBox = sender as RichTextBox;

            if (string.Compare(postRichTextBox.Text, "What's on your mind?") == 0)
            {
                postRichTextBox.Text = "";
                postRichTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void PostTextBox_MouseLeave(object sender, EventArgs e)
        {
            RichTextBox postRichTextBox = sender as RichTextBox;
            if ((string.IsNullOrEmpty(postRichTextBox.Text)))
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
                            fetchUserPosts();
                        }
                        break;
                    }
                case (int)eTabPageType.FriendsPage:
                    {
                        if (!m_DataFetchIndicator.AreFriendsWereFetch)
                        {
                            m_FriendsPage.fetchUsersFriends();
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
            }
        }
    }
}
