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
            foreach(User friend in m_user.Friends)
            {
                createFriendsForm(friend);
            }
        }

        private void createFriendsForm(User i_friend)
        {
           PictureBox friendsPicture = new PictureBox();
           Label friendsName = new Label();
           friendsPicture.LoadAsync(i_friend.PictureSmallURL);
           friendsName.Text = i_friend.FirstName + "" + i_friend.LastName;
           FriendsTab.Controls.Add(friendsPicture);
            FriendsTab.Controls.Add(friendsName);
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

            for( int i = 0; i < 5; i++)
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
    }
}
