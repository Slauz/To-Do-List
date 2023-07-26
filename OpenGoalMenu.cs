using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class OpenGoalMenu : ICommand
    {
        private Goal ChosenGoal;
        public OpenGoalMenu(Goal ChosenGoal) { this.ChosenGoal = ChosenGoal; }
        public void Execute(Application App)
        {
            Console.Clear();
            Console.WriteLine($"{ChosenGoal._Goal}\n");
            Console.WriteLine(" 1. Назад.");
            Console.WriteLine(" 2. Изменить цель.");
            Console.WriteLine(" 3. Изменить дату окончания.");
            Console.WriteLine(" 4. Отметить как выполнения.");
            Console.WriteLine(" 5. Удалить цель.");

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
                        App.Command = new OpenChangeGoalMenu(ChosenGoal);
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        App.Command = new OpenChangeEndDateMenu(ChosenGoal);
                        break;
                    }
                case ConsoleKey.D4:
                    {
                        ChosenGoal.Complete();
                        break;
                    }
                case ConsoleKey.D5:
                    {
                        App.Storage.RemoveData(ChosenGoal);
                        App.Command = new OpenToDoList();
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
