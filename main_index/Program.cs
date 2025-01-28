using System;

namespace P32.lesson11_12
{
    public class Lesson11_12_properties
    {
         public static void Main(string[] args)
         {
             Human human = new Human();
             Human human2 = new Human();
             
             human.Name = "James"; //set
             human2.Name = "Alice"; //set
             
             human.Salary = 1000;
             human2.Salary = 1500;
             
             Console.WriteLine(human.Name);
             
             Console.WriteLine("Salary = " + human.Salary);
             
             Console.WriteLine(human2.Name); //get
             
             Console.WriteLine("Salary = " + human2.Salary);
             
             
             human.Salary += 200; // Increase salary
             Console.WriteLine($"{human.Name} new salary: {human.Salary}");

             human2.Salary -= 100; // Decrease salary
             Console.WriteLine($"{human2.Name} new salary: {human2.Salary}");

             if (human.Salary > human2.Salary)
             {
                 Console.WriteLine($"human salary > human2 salary");
             }
             
             else if (human2.Salary > human.Salary)
             {
                 Console.WriteLine($"human2 salary > human salary");
             }
             
             else if (human.Salary == human2.Salary)
             {
                 Console.WriteLine($"human salary == human2 salary");
             }
             
             Console.WriteLine($"Salaries equal (Equals)? {human.Salary.Equals(human2.Salary)}");
         }
    }


    class Human
    {
        private string name; //properties

        private int Age { get; set; } = 16;

        private decimal salary;
        
        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value >= 0)
                {
                    salary = value;
                }
            }
        }


        public string Name
        {
            get => name; 
            set => name = value; 
        }

        private void show()
        {
            Console.WriteLine("Name: {0}", name);
        }
    }
}