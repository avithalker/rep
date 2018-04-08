using System;
using System.Text;
namespace B18_Ex01_3
{
    public class Program
    {
        public static void Main()
        {
            int hourglassHeight;

            Console.WriteLine("Please enter your desired hourglass height:");
            hourglassHeight = int.Parse(Console.ReadLine());
            hourglassHeight = changeHeightToOdd(hourglassHeight);
            printHourglass(hourglassHeight);
        }

        private static int changeHeightToOdd(int i_hourglassHeight)
        {
            if (i_hourglassHeight % 2 == 0)
            {
                i_hourglassHeight++;
            }

            return i_hourglassHeight;
        }

        private static string setStars(int i_numOfStars)
        {
            StringBuilder stars = new StringBuilder("");

            for (int i = 0; i < i_numOfStars; i++)
            {
                stars.Append("*");         
            }

            return stars.ToString();
        }

        private static string setSpaces(int i_numOfSpaces)
        {
            StringBuilder spaces = new StringBuilder("");
            for (int i = 0; i < i_numOfSpaces; i++)
            {
                spaces.Append(" ");
            }

            return spaces.ToString();
        }

        public static void printHourglass(int i_hourglassHeight)
        {
            string newLine = Environment.NewLine;
            const int k_secondPartPrintPoint = 3;
            StringBuilder hourglass = new StringBuilder("");
        
            for (int i = i_hourglassHeight; i > 0; i -= 2)
            {
                hourglass.Append(setSpaces((i_hourglassHeight - i) / 2));
                hourglass.Append(setStars(i));
                hourglass.Append(setSpaces((i_hourglassHeight - i) / 2));
                hourglass.Append(newLine);     
            }

            for (int i = k_secondPartPrintPoint; i <= i_hourglassHeight; i += 2)
            {
                hourglass.Append(setSpaces((i_hourglassHeight - i) / 2));
                hourglass.Append(setStars(i));
                hourglass.Append(setSpaces((i_hourglassHeight - i) / 2));
                hourglass.Append(newLine);
            }

            Console.WriteLine(hourglass);
        }   
    }
}