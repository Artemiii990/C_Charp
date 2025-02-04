using System;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;


namespace file_project_1
{
    public class IOproject1
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("============= Text ==============");

            string pathText = "C:\\Users\\mehan\\Downloads\\text1.txt";

            using (StreamWriter writer = new StreamWriter(pathText))
            {
                writer.WriteLine("Лучше него - нет никого!(Евгений Александрович)");
            }

            using (StreamReader reader = new StreamReader(pathText))
            {
                string str = reader.ReadLine();
                Console.WriteLine("File data:" + str);
            }
        }
    }
    
}