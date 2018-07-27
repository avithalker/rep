using System;
using System.Windows.Forms;
using DesktopFacebook.Forms;

namespace DesktopFacebook
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginUserForm());
        }
    }
}
