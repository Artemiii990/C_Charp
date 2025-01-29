using System;
using System.Collections.Generic;

namespace generic_index1
{
    class Program
    {
        static T MaxItem<T>(T a, T b, T c) where T : IComparable<T>
        {
            T max = a;
            if (b.CompareTo(max) > 0) max = b;
            if (c.CompareTo(max) > 0) max = c;
            return max;
        }
        
        static T MinItem<T>(T a, T b, T c) where T : IComparable<T>
        {
            T min = a;
            if (b.CompareTo(min) < 0) min = b;
            if (c.CompareTo(min) < 0) min = c;
            return min;
        }

        
        static void Sum_items<T>(IEnumerable<T> coll)
        {
            dynamic sum = 0;
            foreach (var item in coll)
            {
                sum += item;
            }
            Console.WriteLine("Сумма всех чисел массива:" + sum);
        }

        

        public static void Main(string[] args)
        {
            int a = 45;
            int b = 55;
            int c = 30;
            
            int maxInt = MaxItem(a, b, c);
            Console.WriteLine($"Максимальное целое число: {maxInt}"); 

            int minInt = MinItem(a, b, c);
            Console.WriteLine($"Минимальное целое число: {minInt}"); 

            int[] arr = [40, 71, 12, 73, 47];
            
            Sum_items<int>(arr);

        }
    }
}