using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckersWindowApp.Forms;
using CheckersWindowApp;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            GameSettingsForm gameSettingsForm = new GameSettingsForm();
            gameSettingsForm.ShowDialog();
        }
      
    }
}
