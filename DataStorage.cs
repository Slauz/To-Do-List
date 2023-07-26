using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace ToDoList
{
    [Serializable]

    class DataStorage
    {
        private List<Goal> data = new List<Goal>();

        public int dataCount { get; private set; } = 0;
        public DataStorage() { }
        
        public void AddData(Goal d)
        {
            data.Add(d);
            dataCount++;
        }
        public void RemoveData(Goal d) 
        {
            data.Remove(d);
            dataCount--; 
        }
        public Goal GetData(int index) => data[index];
        public void serialize()
        {
            try
            {
                File.WriteAllText("data.json", string.Empty);
                using (StreamWriter stream = new StreamWriter("data.json", append: true))
                {
                    foreach (Goal g in data)
                    {
                        string json = JsonConvert.SerializeObject(g);
                        stream.WriteLine(json);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void deserialize()
        {
            try
            {
                using (StreamReader file = new StreamReader("data.json"))
                {
                    List<Goal> goals = new List<Goal>();
                    while (!file.EndOfStream)
                    {
                        string line = file.ReadLine();
                        Goal goal = JsonConvert.DeserializeObject<Goal>(line);
                        if (goal != null)
                        {
                            goals.Add(goal);
                            dataCount++;
                        }
                    }
                    data = goals;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
