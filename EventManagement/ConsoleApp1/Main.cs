using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement
{
    class Program
    {
        static void Main()
        { //Main file which runs the methods in the Task Class

            // Making the objects of TaskManager to use the methods 
            TaskManager taskManager = new TaskManager();
            taskManager.Run();
            taskManager.DisplayTask();
        }
    }
}
