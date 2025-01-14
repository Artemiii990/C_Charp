using System;

namespace lesson5_6_hometask
{
    public class index_2
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите слова:");
            string sentence = Console.ReadLine();

            string word = "";
            string maximum = "";

            foreach (char c in sentence)
            {
                if (char.IsLetter(c))
                {
                    word += c;
                }
                else
                {
                    if (word.Length > maximum.Length)
                    {
                        maximum = word;
                    }

                    word = "";
                }
            }

            // Проверка последнего слова
            if (word.Length > maximum.Length)
            {
                maximum = word;
            }

            Console.WriteLine("Самое длинное слово: " + maximum);
        }
    }

}