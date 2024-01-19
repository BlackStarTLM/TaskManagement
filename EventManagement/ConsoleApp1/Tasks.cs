using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Tasks
    {   


        public string TaskName { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return $"The Task {TaskName} is {IsCompleted}";
        }
    }
}
