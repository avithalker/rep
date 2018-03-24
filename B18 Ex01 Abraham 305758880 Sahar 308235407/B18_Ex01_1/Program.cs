using System;

namespace B18_Ex01_1
{
    public class Program
    {
        public const int k_BinaryNumberLength = 9;
        public const char k_BinaryZero = '0';
        public const char k_BinaryOne = '1';

        static void Main()
        {
            string binaryNumber1 = getNumberFromUser();
            string binaryNumber2 = getNumberFromUser();
            string binaryNumber3 = getNumberFromUser();
            int decimalNumber1 = convertBinaryStringToDecimal(binaryNumber1);
            int decimalNumber2 = convertBinaryStringToDecimal(binaryNumber2);
            int decimalNumber3 = convertBinaryStringToDecimal(binaryNumber3);
            double averageZeroCount = getDigitCountAverage(binaryNumber1, binaryNumber2, binaryNumber3, k_BinaryZero);
            double averageOneCount = getDigitCountAverage(binaryNumber1, binaryNumber2, binaryNumber3, k_BinaryOne);
            int powerOfTwoConter = getPowerOfTwoCounter(decimalNumber1, decimalNumber2, decimalNumber3);
            double averageNumber = calculateAverage(decimalNumber1, decimalNumber2, decimalNumber3);


            Console.WriteLine("The numbers in decimal format are:");
            Console.WriteLine(decimalNumber1);
            Console.WriteLine(decimalNumber2);
            Console.WriteLine(decimalNumber3);
            Console.WriteLine(string.Format("Average count of {0} is: {1}", k_BinaryZero, averageZeroCount));
            Console.WriteLine(string.Format("Average count of {0} is: {1}", k_BinaryOne, averageOneCount));
            Console.WriteLine(string.Format("There are {0} numbers which are power of two", powerOfTwoConter));
            //todo: decreasing seria
            Console.WriteLine(string.Format("The average number is: {0}", averageNumber));

        }

        private static string getNumberFromUser()
        {
            bool isInputValid = false;
            string binaryNumber;

            do
            {
                Console.WriteLine("Please enter a number in binary format");
                binaryNumber = Console.ReadLine();
                isInputValid = isBinaryNumber(binaryNumber);
                if(!isInputValid)
                {
                    Console.WriteLine("Invalid input! try again.");
                }

            } while (!isInputValid);

            return binaryNumber;
        }

        private static bool isBinaryNumber(string i_Number)
        {
            bool isValidNumber = true;

            if(i_Number.Length!=k_BinaryNumberLength)
            {
                isValidNumber = false;
            }

            for (int i = 0; i < i_Number.Length && isValidNumber; i++)
            {
                if (i_Number[i] != '1' && i_Number[i] != '0')
                {
                    isValidNumber = false;
                }
            }

            return isValidNumber;
        }

        private static int convertBinaryStringToDecimal(string i_BinaryString)
        {
            const int k_Base = 2;
            int power = 0;
            int currentDigit = 0;
            int decimalNumber = 0;

            for (int i = i_BinaryString.Length - 1; i <= 0; i--)
            {
                currentDigit = int.Parse(i_BinaryString[i].ToString());
                decimalNumber += currentDigit * (int)Math.Pow(k_Base, power);
            }

            return decimalNumber;
        }

        private static int getPowerOfTwoCounter(int i_DecimalNumber1, int i_DecimalNumber2, int i_DecimalNumber3)
        {
            int powerOfTwoCounter = 0;

            if(isPowerOfTwo(i_DecimalNumber1))
            {
                powerOfTwoCounter++;
            }

            if (isPowerOfTwo(i_DecimalNumber2))
            {
                powerOfTwoCounter++;
            }

            if (isPowerOfTwo(i_DecimalNumber3))
            {
                powerOfTwoCounter++;
            }

            return powerOfTwoCounter;
        }

        private static bool isPowerOfTwo(int i_Number)
        {
            const int k_Base = 2;
            double logResult = Math.Log(i_Number, k_Base);
            double roundedResult = Math.Round(logResult);

            return roundedResult == logResult;
        }

        private static double getDigitCountAverage(string i_BinaryNumber1, string i_BinaryNumber2, string i_BinaryNumber3, char i_Digit)
        {
            const int k_NumbersCount = 3;
            int digitCount = 0;

            digitCount += getDigitCounter(i_BinaryNumber1, i_Digit);
            digitCount += getDigitCounter(i_BinaryNumber2, i_Digit);
            digitCount += getDigitCounter(i_BinaryNumber3, i_Digit);
            return digitCount / k_NumbersCount;
        }

        private static int getDigitCounter(string i_BinaryNumber, char i_Digit)
        {
            int counter = 0;

            for (int i = 0; i < i_BinaryNumber.Length; i++)
            {
                if (i_BinaryNumber[i] == i_Digit)
                {
                    counter++;
                }
            }

            return counter;
        }

        private static double calculateAverage(int i_Number1,int i_Number2,int i_Number3)
        {
            int k_NumberCount = 3;

            return (i_Number1 + i_Number2 + i_Number3) / k_NumberCount;
        }
    }
}