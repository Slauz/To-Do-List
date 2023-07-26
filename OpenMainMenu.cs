using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class OpenMainMenu : ICommand
    {
        public OpenMainMenu() { }
        public void Execute(Application App)
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в \"Список дел\"");
            Console.WriteLine(" 1. Перейти к списку дел.");
            Console.WriteLine(" 2. \"Благодарности\".");
            Console.WriteLine(" 3. Выйти.");

            ConsoleKeyInfo PressedKey = Console.ReadKey();

            switch (PressedKey.Key)
            {
                case ConsoleKey.D1:
                    {
                        App.Command = new OpenToDoList();
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        App.Command = new OpenCreditMenu();
                        break;
                    }
                case ConsoleKey.D3: 
                    {
                        App.Command = null;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
