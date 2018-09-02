using System;
using System.Drawing;
using System.Windows.Forms;
using DesktopFacebook.Business;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.Components.UserControls
{
    public partial class FacebookPostControl : UserControl
    {
        private string m_TaggedFriends;

        public event Action<string, string> OnPostReady;
        public event Action<string, string> OnPictureReady;

        public FacebookPostControl()
        {
            InitializeComponent();
        }

        public string TaggedFriends
        {
            get { return m_TaggedFriends; }
            set { m_TaggedFriends = value; }
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
                    NotifyPostObservers(PostTextBox.Text, i_TaggedFriendIDs: m_TaggedFriends);
                }
                else
                {
                    if (!string.IsNullOrEmpty(m_TaggedFriends))
                    {
                        MessageBox.Show("Unable to post photo + tags. Tags can be made only with regular post");
                    }
                    else
                    {
                        NotifyPhotoObservers(PreviewPhotoPictureBox.ImageLocation, PostTextBox.Text);
                    }
                }

                CleanPostControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Post Action Failed: " + ex.Message);
            }
        }

        private void NotifyPhotoObservers(string i_ImageLocation, string i_Text)
        {
            if(OnPictureReady != null)
            {
                OnPictureReady(i_ImageLocation, i_Text);
            }
        }

        private void NotifyPostObservers(string i_Text, string i_TaggedFriendIDs)
        {
            if(OnPostReady !=null)
            {
                OnPostReady(i_Text, i_TaggedFriendIDs);
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
    }
}
