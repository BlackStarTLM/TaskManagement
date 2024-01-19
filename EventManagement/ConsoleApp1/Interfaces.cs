using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{   /// <summary>
/// Making an interface for displaying the Updates Task list and giving out the specific task process progress.
/// </summary>
    interface ITaskManager
    {
         void DisplayTaskList();
         void DisplayTask();
    }
}
