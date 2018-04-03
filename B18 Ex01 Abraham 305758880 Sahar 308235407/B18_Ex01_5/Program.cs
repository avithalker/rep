using System;

namespace B18_Ex01_5
{
    public class Program
    {

        public static void Main()
        {
            int number = getNumberFromUser();
            const bool k_FindBiggestDigit = true;

            Console.WriteLine(string.Format("The biggest digit in the number is: {0}", findDigit(number, k_FindBiggestDigit)));
            Console.WriteLine(string.Format("The smallest digit in the number is: {0}", findDigit(number, !k_FindBiggestDigit)));
            Console.WriteLine(string.Format("The number contains {0} even digits", getEvenDigitCount(number)));
            Console.WriteLine(string.Format("There are {0} smaller digit than the unity digit", getSmallerThanUnityDigitCounter(number)));
        }

        private static int getNumberFromUser()
        {
            const int k_NumberLength = 6;
            bool isNumberValid;
            string numberAsString = string.Empty;
            int userNumber = 0;

            do
            {
                isNumberValid = true;
                Console.WriteLine("Please enter a {0} digit positive number:", k_NumberLength);
                numberAsString = Console.ReadLine();
                if (numberAsString.Length != k_NumberLength)
                {
                    Console.WriteLine("Invalid input. Number must have {0} digits", k_NumberLength);
                    isNumberValid = false;
                }

                if (isNumberValid)
                {
                    if (!int.TryParse(numberAsString, out userNumber))
                    {
                        Console.WriteLine("invalid input. Must contain only numbers!");
                        isNumberValid = false;
                    }
                }

                if(isNumberValid && userNumber <= 0)
                {
                    Console.WriteLine("Invalid input. Must be positive");
                    isNumberValid = false;
                }
            }
            while (!isNumberValid);

            return userNumber;
        }

        private static int findDigit(int i_Number, bool i_FindMaxDigit)
        {
            int requestedDigit = i_Number % 10;
            int currentDigit = 0;

            while (i_Number != 0)
            {
                currentDigit = i_Number % 10;
                requestedDigit = getDigitByCompare(requestedDigit, currentDigit, i_FindMaxDigit);
                i_Number = i_Number / 10;
            }

            return requestedDigit;
        }

        private static int getDigitByCompare(int i_Digit1, int i_Digit2, bool i_GetMaxDigit)
        {
            int requestedDigit = i_Digit1;

            if (i_GetMaxDigit)
            {
                if (i_Digit2 > i_Digit1)
                {
                    requestedDigit = i_Digit2;
                }
            }
            else
            {
                if (i_Digit2 < i_Digit1)
                {
                    requestedDigit = i_Digit2;
                }
            }

            return requestedDigit;
        }

        private static int getEvenDigitCount(int i_Number)
        {
            int evenDigitCounter = 0;
            int currentDigit = 0;

            while (i_Number != 0)
            {
                currentDigit = i_Number % 10;
                if (currentDigit % 2 == 0)
                {
                    evenDigitCounter++;
                }

                i_Number = i_Number / 10;
            }

            return evenDigitCounter;
        }

        private static int getSmallerThanUnityDigitCounter(int i_Number)
        {
            int unityDigit = i_Number % 10;
            int counter = 0;
            int currentDigit;

            while(i_Number != 0)
            {
                currentDigit = i_Number % 10;
                if (currentDigit < unityDigit)
                {
                    counter++;
                }

                i_Number = i_Number / 10;
            }

            return counter;
        }
    }
}
