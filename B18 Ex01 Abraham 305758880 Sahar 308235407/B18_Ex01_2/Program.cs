using System;

namespace B18_Ex01_2
{
    public class Program
    {
       public static void Main()
        {
            const string k_fiveStars = "*****";
            const string k_threeStars = "***";
            const string k_oneStar = "*";
            string newline = Environment.NewLine;

            Console.WriteLine(string.Format("{1}{0} {2} {0}  {3}  {0} {2} {0}{1}", newline, k_fiveStars, k_threeStars, k_oneStar));
        }
    }
}
