using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper;

namespace C18_Ex01_Abraham_305758880_Sahar_308235407.Forms
{
    public partial class LoginUserForm : Form
    {
        private UserProfileForm m_UserProfileForm;

        public LoginUserForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginResult result = FacebookService.Login("193793304621904", "public_profile", "user_birthday", "user_friends");

            ////FacebookService.Logout(() => { });
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
