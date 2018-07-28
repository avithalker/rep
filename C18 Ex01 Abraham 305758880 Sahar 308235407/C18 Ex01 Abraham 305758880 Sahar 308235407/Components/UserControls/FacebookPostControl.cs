using DesktopFacebook.Business;
using FacebookWrapper.ObjectModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopFacebook.Components.UserControls
{
    public partial class FacebookPostControl : UserControl
    {
        FacebookUserManager m_FacebookUserManager;
        private string m_TaggedFriends;

        public FacebookPostControl()
        {
            InitializeComponent();
        }

        public string TaggedFriends
        {
            get { return m_TaggedFriends; }
            set { m_TaggedFriends = value; }
        }

        public FacebookUserManager UserManager
        {
            set
            {
                m_FacebookUserManager = value;
            }
        }
            
        private void CleanPostControls()
        {
            PreviewPhotoPictureBox.Image = null;
            PostTextBox.Clear();
            ClearImagePictureBox1.Hide();
        }

        private void PostButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (PreviewPhotoPictureBox.Image == null)
                {
                    int wallPostXLocation = AttachPhotoPictureBox1.Location.X;
                    int wallPostYLocation = AttachPhotoPictureBox1.Location.Y + AttachPhotoPictureBox1.Height + 40;
                    Status postedStatus = m_FacebookUserManager.NativeClient.PostStatus(PostTextBox.Text,i_TaggedFriendIDs:m_TaggedFriends);
                //    AddNewWallPostToExistWall(m_FacebookUser.Posts[0], wallPostXLocation, wallPostYLocation);
                }
                else
                {
                    if (!string.IsNullOrEmpty(m_TaggedFriends))
                    {
                        MessageBox.Show("Unable to post photo + tags. Tags can be made only with regular post");
                    }
                    else
                    {
                        m_FacebookUserManager.NativeClient.PostPhoto(PreviewPhotoPictureBox.ImageLocation, PostTextBox.Text);
                    }
                }

                CleanPostControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Post Action Failed: " + ex.Message);
            }
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

    }
}
