using System;
using System.Security.Cryptography.X509Certificates;

namespace lesson3_4 
{
    public class index3_4
    {
        public static void Main(string[] args)
        {
            string str = "Hello World!";
            char[] arr = str.ToCharArray();
            foreach (var item in arr)
            {
                Console.WriteLine(item + "");
            }
            
            str = "Hello World!";
            int index = str.IndexOf("World");
            Console.WriteLine("index = " + index);
        }
    }
}