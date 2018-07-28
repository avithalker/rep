using System;
using System.Windows.Forms;
using FacebookWrapper;
using DesktopFacebook.Business;

namespace DesktopFacebook.Forms
{
    public partial class LoginUserForm : Form
    {
        private UserProfileForm m_UserProfileForm;
        private FacebookUserManager m_UserManager;

        public LoginUserForm()
        {
            InitializeComponent();
            m_UserManager = new FacebookUserManager();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // todo: change the appid!!!! to the original!!
            LoginResult result= m_UserManager.Login();

           // FacebookService.Logout(() => { });
            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_UserProfileForm = new UserProfileForm(m_UserManager);
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
