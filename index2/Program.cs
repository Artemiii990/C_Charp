using System;
using System.Security.Cryptography.X509Certificates;

namespace home_task_10_11

{
    public class index2
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите строку из 0 и 1:");
            string binaryString = Console.ReadLine();

            try
            {
                int decimalNumber = ConvertBinaryToDecimal(binaryString);
                Console.WriteLine("Преобразованное число: " + decimalNumber);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Число выходит за пределы диапазона типа int.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Некорректный формат введенной строки (не двоичное число).");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Введенная строка пустая.");
            }
        }

        public static int ConvertBinaryToDecimal(string binaryString)
        {
            if (string.IsNullOrEmpty(binaryString))
            {
                throw new ArgumentNullException("Введенная строка пустая.");
            }

            int decimalNumber = 0;
            try
            {
                checked
                {
                    for (int i = 0; i < binaryString.Length; i++)
                    {
                        char c = binaryString[i];
                        if (c != '0' && c != '1')
                        {
                            throw new FormatException("Некорректный формат введенной строки (не двоичное число).");
                        }

                        decimalNumber = decimalNumber * 2 + (c - '0');
                    }
                }
            }
            catch (OverflowException ex)
            {
                throw new OverflowException("Переполнение int",
                    ex); 
            }

            return decimalNumber;
        }
    }
}