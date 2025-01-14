using System;
using System.Security.Cryptography.X509Certificates;

namespace lesson5_6
{
    public class index5_6
    {
        public static void Sum(int a, int[] array)
        {
           int sum = 0;
           foreach (int el in array)
           {
               sum += el;
           }
           Console.WriteLine(sum);
        }

        public static void Main(string[] args)
        {
            int[] array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];
            Sum(1,array);
        } 
    }
}
