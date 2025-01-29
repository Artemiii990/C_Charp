using System;
using System.Collections.Generic;
using System.IO.Pipelines;


namespace lambda_task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 7, 14, 21, 28, 35, 42, 10, 15, 20, 25, 50, 60, 77 };

           
            Func<int[], int, int> countMultiples = (arr, divisor) => arr.Count(num => num % divisor == 0);
            
            Console.WriteLine($"Количество чисел, кратных 7: {countMultiples(numbers, 7)}"); 
            numbers
                .Where(num => num % 7 == 0)
                .ToList()
                .ForEach(item => Console.WriteLine(" " + item));
            Console.WriteLine($"Количество чисел, кратных 5: {countMultiples(numbers, 5)}"); 
            Console.WriteLine($"Количество чисел, кратных 3: {countMultiples(numbers, 3)}"); 
        }
    }
}