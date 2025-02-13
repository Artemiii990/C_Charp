using System;
using System.Collections.Generic;
using System.Globalization;


namespace Exam_Slovnik
{


    abstract class New_Dic
    {
        public abstract void Create_Dictionary(string name_language);
        
        public abstract void AddWord(string name_language, string word, string translation);
        
        public abstract void ShowWords(string name_language);

        public abstract string GetTranslation(string name_language, string wordToTranslate);
        public abstract void Delete_Dictionary(string name_language);


    }

    class Create : New_Dic
    {
        public Dictionary<string, Dictionary<string, string>> dictionaries = new Dictionary<string, Dictionary<string, string>>();

        public override void Create_Dictionary(string name_language)
        {
            if (!dictionaries.ContainsKey(name_language))
            {
                dictionaries[name_language] = new Dictionary<string, string>();
                Console.WriteLine($"Словарь '{name_language}' создано.");
            }
            else
            {
                Console.WriteLine($"Словарь '{name_language}' уже существует.");
            }
        }

        public override void Delete_Dictionary(string name_language)
        {
            if (dictionaries.Remove(name_language))
            {
                Console.WriteLine($"Словарь {name_language} успешно удален.");
            }
            else
            {
                Console.WriteLine($"Словарь {name_language} не был найден.");
            }

        }

        public override void AddWord(string name_language, string word, string translation)
        {
            if (dictionaries.ContainsKey(name_language))
            {
                if (!dictionaries[name_language].ContainsKey(word))
                {
                    dictionaries[name_language].Add(word, translation);
                    Console.WriteLine($"Слово '{word}' добавлено в словарь '{name_language}'.");
                }
                else
                {
                    Console.WriteLine($"Слово '{word}' уже существует в словаре '{name_language}'.");
                }

                while (true)
                {
                    Console.Write("Добавить еще слово в словарь (да/нет): ");
                    string answer = Console.ReadLine().ToLower();

                    if (answer == "да")
                    {
                        Console.Write("Введите слово: ");
                        string newWord = Console.ReadLine();
                        Console.Write("Введите перевод: ");
                        string newTranslation = Console.ReadLine();
                        AddWord(name_language, newWord, newTranslation);
                    }
                    else
                    {
                        break;
                    }
                }

            }
            else
            {
                Console.WriteLine($"Словаря  '{name_language}' не существует.");
            }
        }


        public override void ShowWords(string name_language)
        {
            if (dictionaries.ContainsKey(name_language))
            {
                if (dictionaries[name_language].Count > 0)
                {
                    Console.WriteLine($"Слова в словаре '{name_language}':");
                    foreach (KeyValuePair<string, string> pair in dictionaries[name_language])
                    {
                        Console.WriteLine($"{pair.Key} - {pair.Value}");
                    }
                }
                else
                {
                    Console.WriteLine($"Словарь '{name_language}' пустой.");
                }
            }
            else
            {
                Console.WriteLine($"Словаря '{name_language}' не существует.");
            }
        }



        public override string GetTranslation(string name_language, string word)
        {
            if (!dictionaries.ContainsKey(name_language))
            {
                return "Словарь не найден.";
            }

            Dictionary<string, string> languageDictionary = dictionaries[name_language];
            if (languageDictionary.ContainsKey(word))
            {
                return languageDictionary[word]; 
            }
            else
            {
                return "Перевод не найден.";
            }
        }

        
        public class Show_names_dict
        {
            public static List<string> GetDictionariesNames(Create create)
            {
                return create.dictionaries.Keys.ToList();
            }

        }


    }

    public class Menu
    {
        public static void Main(string[] args)
        {
            Create create = new Create();
            

            while (true)
            {
                Console.WriteLine("Введите ваше действие:" +
                                  "\n1 - Создать новый словарь" +
                                  "\n2 - Ваши Словари" +
                                  "\n3 - Удалить словарь" +
                                  "\n4 - Добавить слово в словарь" +
                                  "\n5 - Перевести слово" +
                                  "\n6 - Просмотреть слова в словаре" +
                                  "\n0 - Выход");


                string choose = Console.ReadLine();
                switch (choose)
                {
                    
                    case "1":

                        Console.WriteLine("Введите название нового словаря:");
                        foreach (string names in Create.Show_names_dict.GetDictionariesNames(create))
                        {
                            Console.WriteLine(names);
                        }
                        string name_dict = Console.ReadLine();
                        create.Create_Dictionary(name_dict);
                        break;
                    
                    case "2":
                        Console.WriteLine("Ваши словари:");
                        foreach (string names in Create.Show_names_dict.GetDictionariesNames(create))
                        {
                            Console.WriteLine(names);
                        }

                        break;


                    case "3":

                        Console.WriteLine("Введите название словаря для удаления:");
                        foreach (string names in Create.Show_names_dict.GetDictionariesNames(create))
                        {
                            Console.WriteLine(names);
                        }
                        string name_delete = Console.ReadLine();
                        create.Delete_Dictionary(name_delete);
                        break;


                    case "4":
                        Console.WriteLine("Введите название словаря:");
                        Console.WriteLine("Ваши словари:");
                        foreach (string names in Create.Show_names_dict.GetDictionariesNames(create))
                        {
                            Console.WriteLine(names);
                        }
                        string name_language = Console.ReadLine();
                        Console.WriteLine("Введите новое слово:");
                        string word = Console.ReadLine();
                        Console.WriteLine("Введите перевод нового слова:");
                        string translation = Console.ReadLine();
                        create.AddWord(name_language, word, translation);

                        break;


                    case "5":
                        Console.WriteLine("Введите название словаря:");
                        Console.WriteLine("Ваши словари:");
                        foreach (string names in Create.Show_names_dict.GetDictionariesNames(create))
                        {
                            Console.WriteLine(names);
                        }
                        string name_lang = Console.ReadLine();
                        Console.WriteLine("Введите слово для перевода:");
                        string wordToTranslate = Console.ReadLine();
                        string translatedWord = create.GetTranslation(name_lang, wordToTranslate);
                        Console.WriteLine("Переведенное слово:");
                        Console.WriteLine(translatedWord);

                        break;
                    
                    case "6": 
                        Console.WriteLine("Введите название словаря в котором хочете просмотреть слова:");
                        Console.WriteLine("Ваши словари:");
                        foreach (string names in Create.Show_names_dict.GetDictionariesNames(create))
                        {
                            Console.WriteLine(names);
                        }
                        string name_lang_show = Console.ReadLine();
                        create.ShowWords(name_lang_show);
                        break;

                        
                    
                    case "0":
                        return;


                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }

    }
}


