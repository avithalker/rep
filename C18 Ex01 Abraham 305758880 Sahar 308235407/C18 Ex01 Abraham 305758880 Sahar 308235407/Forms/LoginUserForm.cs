using FacebookWrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C18_Ex01_Abraham_305758880_Sahar_308235407.Forms
{
    public partial class LoginUserForm : Form
    {
        UserProfileForm m_UserProfileForm;

        public LoginUserForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginResult result = FacebookService.Login("272862089537667", "user_likes",
                                "user_photos", "user_posts", "user_tagged_places", "user_videos", "user_friends", "publish_actions", "manage_pages");

            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_UserProfileForm = new UserProfileForm(result.LoggedInUser);
                m_UserProfileForm.Visible = false;
                m_UserProfileForm.Show();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
        }
    }
}
