using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal interface ICommand
    {
        void Execute(Application App);
    }
}
