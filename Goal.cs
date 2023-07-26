using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToDoList
{
    [Serializable]
    internal class Goal
    {
        public string _Goal { get; private set; }
        public bool _IsDone { get; private set; } = false;
        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            private set
            {
                if (value < DateTime.Now) endDate = DateTime.Now;
                else endDate = value;
            }
        }

        [Newtonsoft.Json.JsonConstructor]
        public Goal(string _Goal, bool _IsDone, DateTime EndDate)
        {
            this._Goal = _Goal;
            this._IsDone = _IsDone;
            this.EndDate = EndDate;
        }
        public Goal(string _Goal,DateTime EndDate)
        {
            this._Goal = _Goal;
            this.EndDate = EndDate;
        }

        public void Complete() => _IsDone = true;

        public void ChangeEndDate(DateTime endDate) => EndDate = endDate;
        public void ChangeGoal(string message) => _Goal = message;
        public void Info() => Console.WriteLine($"Goal: {_Goal} \tDate of the end: {EndDate} \tCurrent status: {(_IsDone ? "Выполнена." : "В процессе.")}");
    }
}
