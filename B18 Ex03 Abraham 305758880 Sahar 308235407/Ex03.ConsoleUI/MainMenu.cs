using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.ConsoleUI.Enums;

namespace Ex03.ConsoleUI
{
    class MainMenu
    {
        public void PrintMainMenu()
        {
            System.Console.WriteLine("Welcome To The Garage Manager App!!");
            System.Console.WriteLine("Please choose from the following options:");
            System.Console.WriteLine("1.Enter new vehicle to the garage");
            System.Console.WriteLine("2.Show vehicle license numbers");
            System.Console.WriteLine("3.Change vehicle's state");
            System.Console.WriteLine("4.Add air to the vehicle's wheels up to maximum ");
            System.Console.WriteLine("5.Refuel Gas Vehicle");
            System.Console.WriteLine("6.Charge electric vehicle");
            System.Console.WriteLine("7.Show vehicle's full data");
        }
    }
}
