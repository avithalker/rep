using System;


namespace B18_Ex01_2
{
    public class Program
    {
        static void Main()
        {
            const string fiveStars = "*****";
            const string threeStars = "***";
            const string oneStar = "*";
            string newline= Environment.NewLine;

            Console.WriteLine(string.Format("{1}{0} {2} {0}  {3}  {0}  {3}  {0} {2} {0}{1}",newline,fiveStars,threeStars,oneStar));
            Console.WriteLine("Press any key to continue...");
            String input =Console.ReadLine();
        }
    }
}
