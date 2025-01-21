using System;
using System.Security.Cryptography.X509Certificates;

namespace home_task_10_11

{
    public class index1
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите предложение из цифр(0-9):");
            string inputString = Console.ReadLine();

            try
            {
                int convertedNumber = ConvertStringToInt(inputString);
                Console.WriteLine("Переделанное число под(int): " + convertedNumber);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Число вышло за диапазон.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Некорректный формат ввода данных.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Введений рядок пустий.");
            }

        }
        
        public static int ConvertStringToInt(string inputString)
        {
            try
            {
                return int.Parse(inputString);
            }
            catch (OverflowException ex)
            {

                throw new OverflowException("Переполнение чисел", ex);
            }
            catch(FormatException ex)
            {
                throw new FormatException("Неверный формат", ex);
            }
            catch(ArgumentNullException ex)
            {
                throw new ArgumentNullException("Рядок не может быть пустым", ex);
            }
        }
    }
}

