using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace C18_Ex01_Abraham_305758880_Sahar_308235407.Forms
{
    public partial class UserProfileForm : Form
    {
        private User m_user;

        public UserProfileForm(User i_user)
        {
            InitializeComponent();
            m_user = i_user;
            initializeUserInfo();
        }

        private void initializeUserInfo()
        {
            UserProfilePicture.LoadAsync(m_user.PictureNormalURL);
            UserNameLabel.Text = m_user.FirstName + " " + m_user.LastName;
            UserGenderLabel.Text = m_user.Gender.ToString();
            UsersBirthdate.Text = m_user.Birthday;
            fetchUsersFriends();
        }

        private void fetchUsersFriends()
        {
            int x = FriendsTab.Bounds.Left;
            int y = FriendsTab.Bounds.Top;
            int lastPicturewidth = 0;
            int lastHeight = 0;

            for(int i = 0; i < 10; i++)
            {
                foreach (User friend in m_user.Friends)
                {
                    createFriendsForm(friend, x, y, ref lastPicturewidth, ref lastHeight);
                    updateLocation(ref x, ref y, lastPicturewidth, lastHeight);
                }
            }
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

        private void createFriendsForm(User i_friend, int i_x, int i_y, ref int io_lastPictureWidth, ref int io_LastHeight)
        {
            PictureBox friendsPicture = new PictureBox();
            Label friendsName = new Label();
            ////friendsName.Size = new Size(30, 30);
            friendsPicture.Load(i_friend.PictureNormalURL);
            friendsPicture.SizeMode = PictureBoxSizeMode.AutoSize;
            friendsPicture.Location = new Point(i_x, i_y);
            friendsName.Text = i_friend.FirstName + " " + i_friend.LastName;
            ////friendsName.Text = "Sahar Haltzi";
            friendsName.Location = new Point(i_x, i_y + friendsPicture.ClientSize.Height + 5);
            FriendsTab.Controls.Add(friendsPicture);
            FriendsTab.Controls.Add(friendsName);
            io_lastPictureWidth = friendsPicture.ClientSize.Width;
            io_LastHeight = friendsPicture.ClientSize.Height + friendsName.Size.Height;
        }

        private void PostButton_Click(object sender, EventArgs e)
        {
            try
            {
                Status postedStatus = m_user.PostStatus(PostTextBox.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Post Action Failed: " + ex.Message);
            }
        }

        private void RecentPostsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int counter = 1;

            foreach(Post post in m_user.Posts)
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
            FacebookObjectCollection<Post> posts = m_user.Posts;
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
            foreach(Checkin checkin in m_user.Checkins)
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

            foreach (Album album in m_user.Albums)
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
    }
}
