using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class OpenAddGoalMenu : ICommand
    {
        public OpenAddGoalMenu() { }
        public void Execute(Application App)
        {
            Console.Clear();
            Console.WriteLine("Добавление цели(задачи).");

            string goal;
            DateTime date;

            Console.WriteLine("Введите цель:");
            goal = Console.ReadLine();

            try
            {
                Console.WriteLine("Введите дату конца: (день/месяц/год/ час:мин)");
                date = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                date = DateTime.Now;
            }

            if (goal == null)
            {
                App.Command = new OpenToDoList();
                return;
            }

            Goal newGoal = new Goal(goal, date);
            App.Storage.AddData(newGoal);
            App.Command = new OpenToDoList();
        }
    }
}  


