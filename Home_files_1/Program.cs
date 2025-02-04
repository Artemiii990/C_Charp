using System;
using System.IO;

namespace Home_files_1
{
    public class Home_IOproject
    {
        public static void Main(string[] args)
        {
            string path = "C:\\Users\\mehan\\Downloads\\arrayText.txt";


            Console.WriteLine("============= Array ==============");
            using (FileStream streamWriter = new FileStream(path, FileMode.Create))
            {
                byte[] buffer = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                streamWriter.Write(buffer, 0, buffer.Length);
            }

            using (FileStream streamReader = new FileStream(path, FileMode.Open))
            {
                byte[] buffer2 = new byte[streamReader.Length];
                streamReader.Read(buffer2, 0, buffer2.Length);
                foreach (var item in buffer2)
                {
                    Console.WriteLine("Item array: " + item);
                }
            }
        }

    }
}

