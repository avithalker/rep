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
            Login();
        }

        private void LoginUserForm_Load(object sender, EventArgs e)
        {
            if (m_UserManager.IsRecognizedUser())
            {
                Login();
            }
        }

        private void Login()
        {
            try
            {
                LoginResult result = m_UserManager.Login(RememberMeCheckBox.Checked);
                if (!string.IsNullOrEmpty(result.AccessToken))
                {
                    showUserProfileForm();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("Failed to login. Info: {0}", ex.Message));
            }
        }

        private void showUserProfileForm()
        {
            m_UserProfileForm = new UserProfileForm(m_UserManager);
            Hide();
            m_UserProfileForm.ShowDialog();
            Show();
        }
    }
}
