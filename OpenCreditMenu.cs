using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class OpenCreditMenu : ICommand
    {
        public OpenCreditMenu() { }
        public void Execute(Application App)
        {
            Console.Clear();
            Console.WriteLine("Благодарности!\n");
            Console.WriteLine(" Приложения было полностью разработано одним человеком.");
            Console.WriteLine(" Этим человеком был Альберт... А стоп, Артем Острижнев AKA Slauz.\n");
            Console.WriteLine(" 1. Назад.");

            ConsoleKeyInfo PressedKey = Console.ReadKey();

            switch (PressedKey.Key)
            {
                case ConsoleKey.D1:
                    {
                        App.Command = new OpenMainMenu();
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
