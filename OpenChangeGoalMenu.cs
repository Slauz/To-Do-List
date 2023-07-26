using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class OpenChangeGoalMenu : ICommand
    {
        private Goal ChosenGoal;
        public OpenChangeGoalMenu(Goal ChosenGoal) { this.ChosenGoal = ChosenGoal; }
        public void Execute(Application App)
        {
            Console.Clear();
            Console.WriteLine("Изменение цели.");

            string goal;
            Console.WriteLine("Введите новую цель:");

            goal = Console.ReadLine();

            if (goal == null)
            {
                App.Command = new OpenGoalMenu(ChosenGoal);
                return;
            }

            ChosenGoal.ChangeGoal(goal);
            App.Command = new OpenGoalMenu(ChosenGoal);
        }
    }
}
