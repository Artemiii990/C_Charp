using System;
using System.Security.Cryptography.X509Certificates;

namespace lesson1_2

{
    public class index1_2
    {
        public static void Main(string[] args)
        {
            byte by = 255; //8 біт 000
            short num1 = 15;
            int number = 25;
            long num2 = 35;

            float num3 = 45.44f; //32
            double num4 = 45.44; //65
            decimal money = 45.6m; //128

            char letter = 'a';

            bool flag = false;
            string str1 = "Hello";
            object obj1 = 45.5;
            obj1 = "Hello";
            
            
            var str2 = "Hello";


            Console.WriteLine("My obj = " + str2);
            Console.Write("Enter new obj = ");
            string new_obj = Console.ReadLine();
            Console.WriteLine("File = " + new_obj);
        }
    }
}

class Student
{
    public int age;
    public string name;

}

{
        Student student = new Student();
        student.age = 25;
        student.name = "James";
}
    
