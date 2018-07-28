using System;
using System.Windows.Forms;
using DesktopFacebook.Business;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.Components.UserControls
{
    public partial class WallPostControl : UserControl
    {
        private Post m_WallPost;
        private FacebookUserManager m_UserManager;

        public WallPostControl(FacebookUserManager i_UserManager, Post i_WallPost)
        {
            InitializeComponent();
            m_WallPost = i_WallPost;
            m_UserManager = i_UserManager;
            InitializeControlers();
        }

        private void InitializeControlers()
        {
            PostLabel.Text = m_WallPost.Message;
            updateLikeCounter();
            if(m_WallPost.From!=null)
            {
                PosterNameLabel.Text = m_WallPost.From.Name;
            }
            
            if (m_WallPost.CreatedTime.HasValue)
            {
                PostDateLabel.Text = m_WallPost.CreatedTime.Value.ToString("dd/MM/yyyy HH:mm:ss");
            }
            else
            {
                PostDateLabel.Text = string.Empty;
            }
        }

        private void CommentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(CommentTextBox.Text))
            {
                try
                {
                    m_WallPost.Comment(CommentTextBox.Text);
                    CommentTextBox.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Unable to post comment. Info: {0}", ex.Message));
                }
            }
        }

        private void WallPostLikeButton1_Click(object sender, EventArgs e)
        {
            try
            {
                bool isOperationSucceed = false;
                if (!m_UserManager.IsFriendLikedPost(m_WallPost, m_UserManager.NativeClient.Id))
                {
                    isOperationSucceed = m_WallPost.Like();
                }
                else
                {
                    isOperationSucceed = m_WallPost.Unlike();
                }

                if (isOperationSucceed)
                {
                    updateLikeCounter();
                }
                else
                {
                    MessageBox.Show(string.Format("Unable to complete the operation"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Unable to complete the operation. Info: {0}", ex.Message));
            }
        }

        private void updateLikeCounter()
        {
            TotalLikesLabel.Text = m_WallPost.LikedBy.Count.ToString();
        }

        private void DeletePostButton1_Click(object sender, EventArgs e)
        {
            try
            {
                m_WallPost.Delete();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Unable to delete post. Info: {0}", ex.Message));
            }
        }
    }
}
