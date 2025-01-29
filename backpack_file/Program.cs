using System;
using System.Collections.Generic;

namespace lambda_index
{
    public delegate void AddItem(string item);
    
    public delegate void DeleteItem(string item);
    
    public delegate void Changes(Action<Backpack> changeAction);

    public class Backpack
    {
        
        public string Color { get; private set; }
        public string Brand { get; private set; }
        public string Cloth { get; private set; }
        public float Weight { get; private set; }
        public int Amount { get; private set; }
        public List<string> Contents { get; private set; } 

        public Backpack(string color, string brand, string cloth, float weight, int amount)
        {
            Color = color;
            Brand = brand;
            Cloth = cloth;
            Weight = weight;
            Amount = amount;
            Contents = new List<string>(); 
        }

        public void AddItem(string item)
        {
            Contents.Add(item);
            Console.WriteLine("В рюкзак добавлен новый предмет: " + item);
        }

        public void DeleteItem(string item)
        {
            if (Contents.Remove(item))
            {
                Console.WriteLine("Из рюкзака удален предмет: " + item);
            }
            else
            {
                Console.WriteLine("Предмет " + item + " не найден в рюкзаке.");
            }
        }

        public void Changes(Action<Backpack> changeAction)
        {
            changeAction(this);
        }

        public void PrintContents()
        {
            Console.WriteLine("Содержимое рюкзака:");
            foreach (string item in Contents)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Backpack myBackpack = new Backpack("Синий", "North Face", "Полиэстер", 2.5f, 1);

            AddItem addItemDelegate = myBackpack.AddItem;
            
            DeleteItem deleteItemDelegate = myBackpack.DeleteItem;

            addItemDelegate("Фонарик");
            addItemDelegate("Спальник");
            addItemDelegate("Палатка");

            myBackpack.PrintContents();

            deleteItemDelegate("Спальник");

            myBackpack.PrintContents();
            
            
            Changes changesDelegate = myBackpack.Changes;
            
            myBackpack.PrintContents();
            
            

            Console.WriteLine($"Новый цвет рюкзака: {myBackpack.Color}");

        }
    }
}
