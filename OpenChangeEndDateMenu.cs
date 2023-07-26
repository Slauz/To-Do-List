using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class OpenChangeEndDateMenu : ICommand
    {
        private Goal ChosenGoal;
        public OpenChangeEndDateMenu(Goal ChosenGoal) { this.ChosenGoal = ChosenGoal; }
        public void Execute(Application App)
        {
            Console.Clear();
            Console.WriteLine("Изменение даты окончания.");

            DateTime endDate;
            Console.WriteLine("Введите новую дату: (день/месяц/год/ час:мин)");
            try 
            {
                endDate = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                endDate = DateTime.Now;
            }

            ChosenGoal.ChangeEndDate(endDate);
            App.Command = new OpenGoalMenu(ChosenGoal);
        }
    }
}
