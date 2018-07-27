using System;
using System.Drawing;
using System.Windows.Forms;
using DesktopFacebook.Business;
using DesktopFacebook.Components.UserControls;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.Forms
{
    public partial class UserProfileForm : Form
    {
        private FacebookUserManager m_UserManager;
        private User m_FacebookUser;

        public UserProfileForm(FacebookUserManager i_UserManager)
        {
            InitializeComponent();
            m_UserManager = i_UserManager;
            m_FacebookUser = m_UserManager.NativeClient;
            initializeUserGeneralInfo();
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

            if(m_FacebookUser.Location!=null)
            {
                UserCurrentCityLabel.Text = m_FacebookUser.Location.Name;
            }
          
            if (m_FacebookUser.RelationshipStatus.HasValue)
            {
                UserRelationshipLabel.Text = m_FacebookUser.RelationshipStatus.Value.ToString();
            }
         //   fetchUsersFriends();
            fetchUserPosts();
        }

        private void fetchUsersFriends()
        {
            int x = FriendsTab.Bounds.Left;
            int y = FriendsTab.Bounds.Top;
            int lastPicturewidth = 0;
            int lastHeight = 0;

            foreach (User friend in m_FacebookUser.Friends)
            {
                AddFriendComponent(friend, x, y, ref lastPicturewidth, ref lastHeight);
                updateLocation(ref x, ref y, lastPicturewidth, lastHeight);
            }
        }

        private void fetchUserPosts()
        {
            int wallPostXLocation = AttachPhotoPictureBox.Location.X;
            int wallPostYLocation = AttachPhotoPictureBox.Location.Y + AttachPhotoPictureBox.Height + 40;
            WallPostControl wallPostControl;

            foreach (Post wallPost in m_FacebookUser.WallPosts)
            {
                wallPostControl = AddWallPostComponent(wallPost, wallPostXLocation, wallPostYLocation);
                wallPostYLocation += wallPostControl.Height + 10;
            }
        }

        private WallPostControl AddWallPostComponent(Post i_wallPost,int i_X,int i_Y)
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
                if(!isFirstWallPost)
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

        private void updateLocation(ref int io_x, ref int io_y, int i_lastPictureWidth, int i_lastHeight)
        {
            if(FriendsTab.ClientSize.Width < io_x + 20)
            {
                io_x = FriendsTab.Bounds.Left;
                io_y += i_lastHeight + 20;
            }
            else
            {
                io_x += i_lastPictureWidth + 20;
            }
        }

        private void AddFriendComponent(User i_friend, int i_x, int i_y, ref int io_lastPictureWidth, ref int io_LastHeight)
        {
            PictureBox friendsPicture = new PictureBox();
            friendsPicture.Name = i_friend.Id;
            Label friendsName = new Label();
            friendsPicture.Load(i_friend.PictureNormalURL);
            friendsPicture.SizeMode = PictureBoxSizeMode.AutoSize;
            friendsPicture.Location = new Point(i_x, i_y);
            friendsName.Text = i_friend.FirstName + " " + i_friend.LastName;
            friendsName.Location = new Point(i_x, i_y + friendsPicture.ClientSize.Height + 5);
            friendsPicture.Click += FriendsPicture_Click;
            friendsPicture.MouseLeave += ClickableControl_MouseLeave;
            friendsPicture.MouseMove += ClickableControl_MouseMove; 
            FriendsTab.Controls.Add(friendsPicture);
            FriendsTab.Controls.Add(friendsName);
            io_lastPictureWidth = friendsPicture.ClientSize.Width;
            io_LastHeight = friendsPicture.ClientSize.Height + friendsName.Size.Height;
        }

        private void FriendsPicture_Click(object sender, EventArgs e)
        {
            PictureBox friendPrictureBox = sender as PictureBox;
            string friendId = friendPrictureBox.Name;
            User friend = m_UserManager.FindFriendById(friendId);
            if (string.IsNullOrEmpty(friend.Link))
            {
                MessageBox.Show(string.Format("Sorry, the facebook page of {0} is not avilabe right now.", friend.Name));
            }
            else
            {
                System.Diagnostics.Process.Start(friend.Link);
            }
        }

        private void PostButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (PreviewPhotoPictureBox.Image == null)
                {
                    int wallPostXLocation = AttachPhotoPictureBox.Location.X;
                    int wallPostYLocation = AttachPhotoPictureBox.Location.Y + AttachPhotoPictureBox.Height + 40;
                    Status postedStatus = m_FacebookUser.PostStatus(PostTextBox.Text);
                    AddNewWallPostToExistWall(m_FacebookUser.Posts[0], wallPostXLocation, wallPostYLocation);
                }
                else
                {
                    m_FacebookUser.PostPhoto(PreviewPhotoPictureBox.ImageLocation, PostTextBox.Text);
                }

                CleanPostControls();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Post Action Failed: " + ex.Message);
            }
        }

        private void RecentPostsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int counter = 1;

            foreach(Post post in m_FacebookUser.Posts)
            {
                while(counter <= 5)
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
            for(int i = 0; i < 5; i++)
            {
                mostPopular = getMostPopularPost(posts);
                TopFivePostsListBox.Items.Add(mostPopular);
                posts.Remove(mostPopular);
            }
        }

        private Post getMostPopularPost(FacebookObjectCollection<Post> i_posts)
        {
            Post mostPopular = i_posts[0];

            foreach(Post post in i_posts)
            {
                if(mostPopular.LikedBy.Count < post.LikedBy.Count)
                {
                    mostPopular = post;
                }
            }

            return mostPopular;
        }

        private void FetchCheckinsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach(Checkin checkin in m_FacebookUser.Checkins)
            {
                CheckinsListBox.Items.Add(checkin.ToString());
            }
        }

        private void FetchAlbumsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int x = AlbumsPanel.Bounds.Left;
            int y = AlbumsPanel.Bounds.Top;
            int lastPictureWidth = 0;
            int lastHeight = 0;

            foreach (Album album in m_FacebookUser.Albums)
            {
                addAlbumDataToPanel(album, x, y, ref lastPictureWidth, ref lastHeight);
                updateLocation(ref x, ref y, lastPictureWidth, lastHeight);
            }
        }

        private void addAlbumDataToPanel(Album i_album, int i_x, int i_y, ref int o_lastPictureWidth, ref int o_lastHeight)
        {
            PictureBox albumPictureBox = new PictureBox();
            Label albumsName = new Label();
            albumPictureBox.Load(i_album.CoverPhoto.URL);
            albumPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            albumPictureBox.Location = new Point(i_x, i_y);
            albumsName.Text = i_album.Name;
            albumsName.Location = new Point(i_x, i_y + albumPictureBox.ClientSize.Height + 5);
            o_lastPictureWidth = albumPictureBox.ClientSize.Width;
            o_lastHeight = albumPictureBox.ClientSize.Height + albumsName.Width;

            AlbumsPanel.Controls.Add(albumPictureBox);
            albumPictureBox.Controls.Add(albumsName);
              
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
            ClearImagePictureBox.Hide();
        }

        private void ClickableControl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void ClickableControl_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void AttachPhotoPictureBox_Click(object sender, EventArgs e)
        {
            if (PictureFileDialog.ShowDialog() == DialogResult.OK)
            {
                PreviewPhotoPictureBox.Load(PictureFileDialog.FileName);
                ClearImagePictureBox.Show();
            }

            PictureFileDialog.FileName = string.Empty;
        }

        private void ClearImagePictureBox_Click(object sender, EventArgs e)
        {
            PreviewPhotoPictureBox.Image = null;
            ClearImagePictureBox.Hide();
        }
    }
}
