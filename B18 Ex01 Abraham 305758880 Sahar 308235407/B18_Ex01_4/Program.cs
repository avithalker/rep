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

            if (isALetter(inputString[0]))
            {
                Console.WriteLine(string.Format("The string has {0} lowercase letters", getNumberOfLowercaseLetters(inputString)));
            }
            else
            {
                Console.WriteLine(string.Format("Is string an even number: {0}", isNumberEven(inputString)));
            }               
        }

        private static string getStringFromUser()
        {
            Console.WriteLine("Please Enter 8-character string which contains only numbers or only letters :\n ");
            string inputString = Console.ReadLine();

            return inputString;
        }

        private static bool isALetter(char o_char)
        {
            return (o_char >= 'a' && o_char <= 'z') || (o_char >= 'A' && o_char <= 'Z');
        }

        private static bool isStringValid(string i_userInputString)
        {
            if (i_userInputString[0] >= '0' && i_userInputString[0] <= '9')
            {
                for (int i = 1; i < i_userInputString.Length; i++)
                {
                    if (!(i_userInputString[0] >= '0' && i_userInputString[0] <= '9'))
                    {
                        return false;
                    }
                }                
            }
            else if (isALetter(i_userInputString[0]))
            {
                for (int i = 1; i < i_userInputString.Length; i++)
                {
                    if (!isALetter(i_userInputString[i]))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
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
