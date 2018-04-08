using System;

namespace B18_Ex01_4
{
    public class Program
    {
        public static void Main()
        {
            string inputString = getStringFromUser();

            while (!isStringValid(inputString))
            {
                inputString = getStringFromUser();
            }

            Console.WriteLine(string.Format("Is string Palindrome: {0}", isStringPalindrome(inputString)));
            if (isStringIncludesOnlyLetters(inputString))
            {
                Console.WriteLine(string.Format("The string has {0} lowercase letters", getNumberOfLowercaseLetters(inputString)));
            }
            else if(isStringIncludesOnlyNumbers(inputString))
            {
                Console.WriteLine(string.Format("Is string an even number: {0}", isNumberEven(inputString)));
            }
        }

        private static string getStringFromUser()
        {
            Console.WriteLine("Please Enter 8-character string which contains only numbers or only letters :");
            string inputString = Console.ReadLine();

            return inputString;
        }

        private static bool isALetter(char o_char)
        {
            return (o_char >= 'a' && o_char <= 'z') || (o_char >= 'A' && o_char <= 'Z');
        }

        private static bool isStringValid(string i_userInputString)
        {
            if(!isStringHasEightCharacters(i_userInputString))
            {
                return false;        
            }
          
            if(isStringIncludesOnlyLetters(i_userInputString) || isStringIncludesOnlyNumbers(i_userInputString))
            {
                return true;
            }
        
         return false;
            
        }

        private static bool isStringHasEightCharacters(string i_userInputString)
        {
            return i_userInputString.Length == 8;
        }

        private static bool isStringIncludesOnlyLetters(string i_userInputString)
        {
            for(int i=0;i<i_userInputString.Length;i++)
            {
                if (!isALetter(i_userInputString[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isANumber(char i_char)
        {
            return (i_char >= '0' && i_char <= '9');
        }

        private static bool isStringIncludesOnlyNumbers(string i_userInputString)
        {
            for (int i = 0; i < i_userInputString.Length; i++)
            {
                if (isANumber(i_userInputString[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isStringPalindrome(string i_userInputString)
        {
            int reverseIndex = i_userInputString.Length - 1;
            for (int i = 0; i < i_userInputString.Length; i++)
            {
                if (i_userInputString[i] != i_userInputString[reverseIndex])
                {
                    return false;
                }

                reverseIndex--;
            }

            return true;
        }

        private static bool isNumberEven(string i_userInputString)
        {
            int inputNumber = int.Parse(i_userInputString);

            return inputNumber % 2 == 0;
        }

        private static int getNumberOfLowercaseLetters(string i_userInputString)
        {
            int numberOfLowercaseLetters = 0;

            for (int i = 0; i < i_userInputString.Length; i++)
            {
                if (i_userInputString[i] >= 'a' && i_userInputString[i] <= 'z')
                {
                    numberOfLowercaseLetters++;
                }
            }

            return numberOfLowercaseLetters;
        }
    }
}
