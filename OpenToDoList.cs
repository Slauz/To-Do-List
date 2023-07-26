using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class OpenToDoList : ICommand
    {
        private int pointer = 0;

        private bool ChooseStatus = false;
        public OpenToDoList() { }
        public void Execute(Application App)
        {
            Console.Clear();
            Console.WriteLine("Список дел.");
            Console.WriteLine(" 1. Назад.");
            Console.WriteLine(" 2. Добавить цель.");
            Console.WriteLine(" 3. Выбрать цель.\n");

            for (int i = 0; i < App.Storage.dataCount; i++)
            {
                if (ChooseStatus && i == pointer) Console.Write(" => ");
                App.Storage.GetData(i).Info();
            }

            ConsoleKeyInfo PressedKey = Console.ReadKey();

            switch (PressedKey.Key)
            {
                case ConsoleKey.D1:
                    {
                        App.Command = new OpenMainMenu();
                        App.Storage.serialize();
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        App.Command = new OpenAddGoalMenu();
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        ChooseStatus = true;
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        if(!ChooseStatus)
                        {
                            break;
                        }

                        if (pointer > 0) pointer--;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        if (!ChooseStatus)
                        {
                            break;
                        }

                        if (pointer < App.Storage.dataCount - 1) pointer++;
                        break;
                    }
                case ConsoleKey.Enter:
                    {
                        if (!ChooseStatus) break;
                        App.Command = new OpenGoalMenu(App.Storage.GetData(pointer));
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
