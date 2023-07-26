using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    static class Menu
    {
        public static void Output(Application App, ICommand Command) => Command.Execute(App);
    }
}
