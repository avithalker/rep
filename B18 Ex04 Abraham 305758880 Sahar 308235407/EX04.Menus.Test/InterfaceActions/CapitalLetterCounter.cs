using System;
using EX04.Menus.Interfaces.MenuItems;

namespace EX04.Menus.Test.InterfaceActions
{
    public class CapitalLetterCounter : IActionObserver
    {
        public void DoAction()
        {
            string input;
            int capitalLetterCounter = 0;

            Console.WriteLine("Please enter a string:");
            input = Console.ReadLine();
            foreach (char letter in input)
            {
                if (letter >= 'A' && letter <= 'Z')
                {
                    capitalLetterCounter++;
                }
            }

            Console.WriteLine("The number of capital letters is: {0}", capitalLetterCounter);
        }
    }
}
