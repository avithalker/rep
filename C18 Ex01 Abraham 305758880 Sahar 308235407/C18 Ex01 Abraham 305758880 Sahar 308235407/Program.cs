using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper;
using C18_Ex01_Abraham_305758880_Sahar_308235407.Forms;

namespace C18_Ex01_Abraham_305758880_Sahar_308235407
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
