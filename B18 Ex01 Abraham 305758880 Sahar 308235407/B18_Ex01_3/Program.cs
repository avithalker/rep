using System;


namespace B18_Ex01_3
{
    public class Program
    {
        

        static void Main()
        {
            Console.WriteLine("Please enter your desired hourglass height:\n");
            int hourglassHeight = int.Parse(Console.ReadLine());
            printHourglass(hourglassHeight);

            Console.WriteLine("Press any key to continue...");
            String input = Console.ReadLine();
        }

        private static string setStars(int i_numOfStars)
        {
            string stars = "";

            for (int i = 0; i < i_numOfStars;i++ )
            {
                stars += "*";         
            }

            return stars;
        }

        private static string setSpaces(int i_numOfSpaces)
        {
            string spaces = "";
            for(int i=0;i<i_numOfSpaces;i++)
            {
                spaces += " ";
            }
            return spaces;
        }

        public static void  printHourglass(int i_hourglassHeight)
        {
            string newLine=Environment.NewLine;
            string hourglass = "";

            for(int i=i_hourglassHeight;i>0;i-=2)
            {
                hourglass+=setSpaces((i_hourglassHeight - i) / 2);
                hourglass+=setStars(i);
                hourglass+=setSpaces((i_hourglassHeight - i) / 2);
                hourglass += newLine;
                
            }
            for(int i=1;i<=i_hourglassHeight;i+=2)
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

