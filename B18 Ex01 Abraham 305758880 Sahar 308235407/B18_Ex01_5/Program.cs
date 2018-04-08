using System;

namespace B18_Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            string numberAsString = getNumberFromUser();
            const bool k_FindBiggestDigit = true;

            Console.WriteLine(string.Format("The biggest digit in the number is: {0}", findDigit(numberAsString, k_FindBiggestDigit)));
            Console.WriteLine(string.Format("The smallest digit in the number is: {0}", findDigit(numberAsString, !k_FindBiggestDigit)));
            Console.WriteLine(string.Format("The number contains {0} even digits", getEvenDigitCount(numberAsString)));
            Console.WriteLine(string.Format("There are {0} smaller digit than the unity digit", getSmallerThanUnityDigitCounter(numberAsString)));
        }

        private static string getNumberFromUser()
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

                if (isNumberValid && userNumber <= 0)
                {
                    Console.WriteLine("Invalid input. Must be positive");
                    isNumberValid = false;
                }
            }
            while (!isNumberValid);

            return numberAsString;
        }

        private static int findDigit(string i_NumberAsString, bool i_FindMaxDigit)
        {
            int requestedDigit;
            int currentDigit = 0;
            int digitIndex = i_NumberAsString.Length - 1;

            int.TryParse(i_NumberAsString[digitIndex] + string.Empty, out requestedDigit);
            digitIndex--;
            while (digitIndex >= 0)
            {
                int.TryParse(i_NumberAsString[digitIndex] + string.Empty, out currentDigit);
                requestedDigit = getDigitByCompare(requestedDigit, currentDigit, i_FindMaxDigit);
                digitIndex--;
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

        private static int getEvenDigitCount(string i_NumberAsString)
        {
            int evenDigitCounter = 0;
            int currentDigit = 0;
            int digitIndex = i_NumberAsString.Length - 1;

            while (digitIndex >= 0)
            {
                int.TryParse(i_NumberAsString[digitIndex] + string.Empty, out currentDigit);
                if (currentDigit % 2 == 0)
                {
                    evenDigitCounter++;
                }

                digitIndex--;
            }

            return evenDigitCounter;
        }

        private static int getSmallerThanUnityDigitCounter(string i_NumberAsString)
        {
            int unityDigit;
            int counter = 0;
            int currentDigit;
            int digitIndex = i_NumberAsString.Length - 1;

            int.TryParse(i_NumberAsString[digitIndex] + string.Empty, out unityDigit);
            digitIndex--;
            while (digitIndex >= 0)
            {
                int.TryParse(i_NumberAsString[digitIndex] + string.Empty, out currentDigit);
                if (currentDigit < unityDigit)
                {
                    counter++;
                }

                digitIndex--;
            }

            return counter;
        }
    }
}
