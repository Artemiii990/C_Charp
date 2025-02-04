using System;
using System.IO;

namespace Home_files_1
{
    public class Home_IOproject
    {
        public static void Main(string[] args)
        {
            string path_parni = "C:\\Users\\mehan\\Downloads\\Parni.txt";
            string path_neparni = "C:\\Users\\mehan\\Downloads\\NeParni.txt";

            Console.WriteLine("============= Parni - NeParni ==============");

            var rand = new Random();
            
            using (StreamWriter parniWriter = new StreamWriter(path_parni))
            {
                for (int i = 0; i < 10000; i++)
                {
                    int number = rand.Next();
                    if (number % 2 == 0)
                    {
                        parniWriter.WriteLine(number);
                    }
                }
            }

            // Запись непарных чисел
            using (StreamWriter neparniWriter = new StreamWriter(path_neparni))
            {
                for (int i = 0; i < 10000; i++)
                {
                    int number = rand.Next();
                    if (number % 2 != 0)
                    {
                        neparniWriter.WriteLine(number); 
                    }
                }
            }

            Console.WriteLine("\nПарные числа:");
            PrintNumbersParni(path_parni);
            Console.WriteLine("\nНепарные числа:");
            PrintNumbersNeParni(path_neparni);
        }

        static void PrintNumbersParni(string path_parni)
        {
            using (StreamReader parni = new StreamReader(path_parni))
            {
                string line;
                while ((line = parni.ReadLine()) != null) 
                {
                    Console.WriteLine(line);
                }
            }
        }

        static void PrintNumbersNeParni(string path_neparni)
        {
            using (StreamReader neparni = new StreamReader(path_neparni))
            {
                string line;
                while ((line = neparni.ReadLine()) != null) 
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
