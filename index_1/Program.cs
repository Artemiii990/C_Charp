using System;

namespace lesson5_6_hometask
{
    public class index_1
    {
        public static void Main(string[] args)
        {
            int arraySize;

            Console.Write("Введите длину массива: ");
            
            while (!int.TryParse(Console.ReadLine(), out arraySize) || arraySize <= 0) // команда для постановления длинны массива и проверки на то что он не меньше нуля
            {
                Console.WriteLine("Ввидете положительное число длинны массива.");
                Console.Write("Введите длину массива: ");
            }

            Random random = new Random();
            int[] array = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                array[i] = random.Next(1, 100);
            }
            
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write(array[i] + " ");
            }
            
            Console.WriteLine("Уникальные числа:");
            bool found = false; // Флаг для отслеживания наличия уникальных дубликатов

            for (int i = 0; i < arraySize; i++)
            {
                int count = 0; // Счетчик вхождений элемента
                for (int j = 0; j < arraySize; j++)
                {
                    if (array[i] == array[j])
                    {
                        count++;
                    }
                }
                if (count == 2) // Уникальный дубликат (встречается ровно 2 раза)
                {
                    Console.Write(array[i] + " ");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Нет уникальных элементов.");
            }
            Console.WriteLine(); 
        }
    }
}