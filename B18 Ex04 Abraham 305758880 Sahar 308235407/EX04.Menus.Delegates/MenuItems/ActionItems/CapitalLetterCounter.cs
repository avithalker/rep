using System;

namespace EX04.Menus.Delegates.MenuItems
{
    public class CapitalLetterCounter : ActionItem
    {
        public CapitalLetterCounter(string i_Title) : base(i_Title)
        {
        }

        public override void DoAction()
        {
            string input;
            int capitalLetterCounter = 0;

            Console.WriteLine("Please enter a string:");
            input = Console.ReadLine();
            foreach(char letter in input)
            {
                if(letter >= 'A' && letter <= 'Z')
                {
                    capitalLetterCounter++;
                }
            }

            Console.WriteLine("The number of capital letters is: {0}", capitalLetterCounter);
        }
    }
}
