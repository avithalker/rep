using System;

namespace B18_Ex01_3
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter your desired hourglass height:\n");
            int hourglassHeight = int.Parse(Console.ReadLine());
            hourglassHeight = changeHeightToOdd(hourglassHeight);
            printHourglass(hourglassHeight);
        }

        private static int changeHeightToOdd(int io_hourglassHeight)
        {
            if (io_hourglassHeight % 2 == 0)
            {
                io_hourglassHeight++;
            }
            
                return io_hourglassHeight;            
        }

        private static string setStars(int i_numOfStars)
        {
            string stars = string.Empty;

            for (int i = 0; i < i_numOfStars; i++)
            {
                stars += "*";         
            }

            return stars;
        }

        private static string setSpaces(int i_numOfSpaces)
        {
            string spaces = string.Empty;
            for (int i = 0; i < i_numOfSpaces; i++)
            {
                spaces += " ";
            }

            return spaces;
        }

        public static void printHourglass(int i_hourglassHeight)
        {
            string newLine = Environment.NewLine;
            string hourglass = string.Empty;

            for (int i = i_hourglassHeight; i > 0; i -= 2)
            {
                hourglass += setSpaces((i_hourglassHeight - i) / 2);
                hourglass += setStars(i);
                hourglass += setSpaces((i_hourglassHeight - i) / 2);
                hourglass += newLine;     
            }

            for (int i = 3; i <= i_hourglassHeight; i += 2)
            {
                hourglass += setSpaces((i_hourglassHeight - i) / 2);
                hourglass += setStars(i);
                hourglass += setSpaces((i_hourglassHeight - i) / 2);
                hourglass += newLine;
            }

            Console.WriteLine(hourglass);
        }   
    }
}