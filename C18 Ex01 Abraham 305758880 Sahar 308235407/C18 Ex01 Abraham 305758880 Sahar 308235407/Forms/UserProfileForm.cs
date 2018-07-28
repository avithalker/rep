﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DesktopFacebook.Business;
using DesktopFacebook.CommonDefines;
using DesktopFacebook.Components.UserControls;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.Forms
{
    public partial class UserProfileForm : Form
    {
        private FacebookUserManager m_UserManager;
        private User m_FacebookUser;
        private DataFetchIndicator m_DataFetchIndicator;

        public UserProfileForm(FacebookUserManager i_UserManager)
        {
            InitializeComponent();
            m_UserManager = i_UserManager;
            m_FacebookUser = m_UserManager.NativeClient;
            m_DataFetchIndicator = new DataFetchIndicator();
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

            if (m_FacebookUser.Location != null)
            {
                UserCurrentCityLabel.Text = m_FacebookUser.Location.Name;
            }

            if (m_FacebookUser.RelationshipStatus.HasValue)
            {
                UserRelationshipLabel.Text = m_FacebookUser.RelationshipStatus.Value.ToString();
            }
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

            m_DataFetchIndicator.AreFriendsWereFetch = true;
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

        private void updateLocation(ref int io_x, ref int io_y, int i_lastPictureWidth, int i_lastHeight)
        {
            io_x += i_lastPictureWidth + 20;

            if (FriendsTab.Width - i_lastPictureWidth <= io_x)
            {
                io_x = FriendsTab.Bounds.Left;
                io_y += i_lastHeight + 20;
            }
        }

        private void AddFriendComponent(User i_friend, int i_x, int i_y, ref int io_lastPictureWidth, ref int io_LastHeight)
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

        private void FetchCheckins()
        {
            CheckinsListBox.DisplayMember = "Description";
            foreach (Checkin checkin in m_FacebookUser.Checkins)
            {
                CheckinsListBox.Items.Add(checkin);
            }

            m_DataFetchIndicator.AreCheckinWereFetch = true;
        }

        private void FetchUserAlbums()
        {
            int k_x = AlbumsPanel.Bounds.Left;
            int y = AlbumsPanel.Bounds.Top;
            TitledPictureControl albumControl = null;

            foreach (Album album in m_FacebookUser.Albums)
            {
                albumControl = addAlbumComponent(album, k_x, y);
                y += albumControl.Height + 10;
            }

            m_DataFetchIndicator.AreAlbumsWereFetch = true;
        }

        private TitledPictureControl addAlbumComponent(Album i_album, int i_x, int i_y)
        {
            TitledPictureControl albumControl = new TitledPictureControl(i_album.PictureAlbumURL, i_album.Name, i_album.Id);

            albumControl.Location = new Point(i_x, i_y);
            albumControl.Click += AlbumControl_Click;
            AlbumsPanel.Controls.Add(albumControl);
            return albumControl;
        }

        private void AlbumControl_Click(object sender, EventArgs e)
        {
            TitledPictureControl albumControl = sender as TitledPictureControl;
            Album album = m_UserManager.FindAlbumById(albumControl.Id);

            SelectedAlbumNameLabel.Text = album.Name;
            fillAlbumPicturePanel(album.Photos);
        }

        private void fillAlbumPicturePanel(FacebookObjectCollection<Photo> i_AlbumPhotos)
        {
            int xLocation = 0;
            int yLocation = 0;
            int marginSpace = 10;

            AlbumPicturesPanel.Controls.Clear();
            foreach (Photo albumPhoto in i_AlbumPhotos)
            {
                PictureBox photoPictureBox = new PictureBox();
                photoPictureBox.Size = new Size(120, 120);
                photoPictureBox.LoadAsync(albumPhoto.PictureNormalURL);
                photoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                photoPictureBox.Location = new Point(xLocation, yLocation);
                AlbumPicturesPanel.Controls.Add(photoPictureBox);

                xLocation += photoPictureBox.Width + marginSpace;
                if (xLocation >= AlbumPicturesPanel.Width - photoPictureBox.Width)
                {
                    xLocation = 0;
                    yLocation += photoPictureBox.Height + marginSpace;
                }
            }
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
                            fetchUsersFriends();
                        }
                        break;
                    }
                case (int)eTabPageType.AlbumPage:
                    {
                        if (!m_DataFetchIndicator.AreAlbumsWereFetch)
                        {
                            FetchUserAlbums();
                        }
                        break;
                    }
                case (int)eTabPageType.CheckinPage:
                    {
                        if (!m_DataFetchIndicator.AreCheckinWereFetch)
                        {
                            FetchCheckins();
                        }
                        break;
                    }
            }
        }

        private void CheckinsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Checkin selectedCheckin = CheckinsListBox.SelectedItem as Checkin;
            fillExtendedChekinData(selectedCheckin);
        }

        private void fillExtendedChekinData(Checkin selectedCheckin)
        {
            CheckinMessgeOutputLabel.Text = selectedCheckin.Message;
            CheckinLocationOutputLabel.Text = selectedCheckin.Description;
            if (selectedCheckin.CreatedTime.HasValue)
            {
                CheckinDateOutputLbel.Text = selectedCheckin.CreatedTime.Value.ToString("dd/MM/yyyy hh:mm");
            }
            else
            {
                CheckinDateOutputLbel.Text = string.Empty;
            }

            List<string> friendsName = new List<string>();
            foreach(User friend in selectedCheckin.WithUsers)
            {
                friendsName.Add(friend.Name);
            }

            CheckinFriendsOutputLabel.Text = string.Join(", ", friendsName);      
        }
    }
}
