using System;
using System.Collections.Generic;

namespace generic_project_2
{
    public delegate void AddUser(string username);
    public delegate void RemoveUser(string username);
    public delegate void AddPasswords(string password);
    public delegate void DeletePasswords(string password);
    public delegate void ShowPasswords(string password);

    public class Management
    {
        private List<string> passwords = new List<string>();
        public Dictionary<string, List<string>> UsersPasswords = new Dictionary<string, List<string>>(); 
        public event AddUser UserAdded;
        public event RemoveUser UserRemoved;
        public event AddPasswords PasswordAdded;
        public event DeletePasswords PasswordDeleted;
        public event ShowPasswords PasswordsShown;


        public void AddUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("Имя пользователя не может быть пустым.");
                return;
            }
            if (!UsersPasswords.ContainsKey(username))
            {
                UsersPasswords.Add(username, new List<string>());
                UserAdded?.Invoke(username);
                Console.WriteLine($"Пользователь '{username}' добавлен.");
            }
            else
            {
                Console.WriteLine($"Пользователь '{username}' уже существует.");
            }
        }

        public void DeleteUser(string username)
        {
            if (UsersPasswords.Remove(username))
            {
                UserRemoved?.Invoke(username);
                Console.WriteLine($"Пользователь '{username}' удален.");
            }
            else
            {
                Console.WriteLine($"Пользователь '{username}' не найден.");
            }
        }

        public void AddPassword(string username, string password) //Добавлен username
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Пароль не может быть пустым.");
                return;
            }
            if (!UsersPasswords.ContainsKey(username))
            {
                Console.WriteLine($"Пользователь '{username}' не найден.");
                return;
            }
            UsersPasswords[username].Add(password);
            PasswordAdded?.Invoke(password);
            Console.WriteLine($"Пароль '{password}' добавлен для пользователя '{username}'.");
        }

        public void DeletePassword(string username, string password) //Добавлен username
        {
            if (!UsersPasswords.ContainsKey(username))
            {
                Console.WriteLine($"Пользователь '{username}' не найден.");
                return;
            }
            if (UsersPasswords[username].Remove(password))
            {
                PasswordDeleted?.Invoke(password);
                Console.WriteLine($"Пароль '{password}' удален для пользователя '{username}'.");
            }
            else
            {
                Console.WriteLine($"Пароль '{password}' не найден для пользователя '{username}'.");
            }
        }

        public void EditPassword(string username, string oldPassword, string newPassword)
        {
            if (!UsersPasswords.ContainsKey(username))
            {
                Console.WriteLine($"Пользователь '{username}' не найден.");
                return;
            }
            int index = UsersPasswords[username].IndexOf(oldPassword);
            if (index != -1)
            {
                UsersPasswords[username][index] = newPassword;
                Console.WriteLine($"Пароль '{oldPassword}' изменен на '{newPassword}' для пользователя '{username}'.");
            }
            else
            {
                Console.WriteLine($"Пароль '{oldPassword}' не найден для пользователя '{username}'.");
            }
        }

        public void ShowAllPasswords()
        {
            if (UsersPasswords.Count == 0)
            {
                Console.WriteLine("Список пользователей пуст.");
                return;
            }
            foreach (KeyValuePair<string, List<string>> userPasswords in UsersPasswords)
            {
                Console.WriteLine($"Пароли для пользователя {userPasswords.Key}:");
                foreach (string password in userPasswords.Value)
                {
                    PasswordsShown?.Invoke(password);
                    Console.WriteLine(password);
                }
            }
        }
    }


    class Program
    {
        public static void Main(string[] args)
        {
            Management manager = new Management();


            manager.UserAdded += UserAddedHandler;
            manager.UserRemoved += UserRemovedHandler;
            manager.PasswordAdded += PasswordAddedHandler;
            manager.PasswordDeleted += PasswordDeletedHandler;
            manager.PasswordsShown += PasswordsShownHandler;


            manager.AddUser("Armen");
            manager.AddUser("Claus");
            manager.AddUser("Michael");
            manager.AddPassword("Claus", "Claus5241");
            manager.AddPassword("Armen", "Armen6213");
            manager.AddPassword("Michael", "Michael1763");
            manager.EditPassword("Claus", "Claus5241", "NewClausPassword");
            manager.ShowAllPasswords();
        }

        static void UserAddedHandler(string username)
        {
            Console.WriteLine($"Обработчик: Пользователь '{username}' добавлен.");
        }

        static void UserRemovedHandler(string username)
        {
            Console.WriteLine($"Обработчик: Пользователь '{username}' удален.");
        }

        static void PasswordAddedHandler(string password)
        {
            Console.WriteLine($"Обработчик: Пароль '{password}' добавлен.");
        }

        static void PasswordDeletedHandler(string password)
        {
            Console.WriteLine($"Обработчик: Пароль '{password}' удален.");
        }
        

        static void PasswordsShownHandler(string password)
        {
            Console.WriteLine($"Обработчик: Выведен пароль: {password}");
        }
    }
}
