using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Application
    {
        public DataStorage Storage { get; private set; } = new DataStorage();

        public ICommand Command { private get; set; } = new OpenMainMenu();
        public void Run()
        {
            Storage.deserialize();

            while (true)
            {
                if (Command == null)
                {
                    Storage.serialize();
                    Environment.Exit(0);
                }
                Menu.Output(this, Command);
            }

        }
    }
}
