using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement
{
    using ConsoleApp1;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Eventing.Reader;
    using System.Security.Cryptography.X509Certificates;
    // Taking interfaces {DisplayTaskList} and {DisplayTask} and inheriting them in class TaskManager

    class TaskManager : ITaskManager
    {
        List<Task> tasks = new List<Task>();
        // Define the Task class with properties
        class Task
        {       //Setting the values for TaskName and IsCompletedValue
            public string TaskName { get; set; }
            public bool IsCompletedValue { get; set; }
            
        }

        // Event and delegates for task completion
        public delegate void TaskCompletedEventHandler(object sender);
        public event TaskCompletedEventHandler TaskCompleted;

    

        // Method to display task list
        /// <summary>
        /// Prints the Task list everytime it is called
        /// Takes task list as an input from the gloabally declared tasks
        /// </summary>
        public void DisplayTaskList()
        {   
            Console.WriteLine("\nTask List:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.TaskName} - {(task.IsCompletedValue ? "Completed" : "Pending")}");
            }
        }

        

        // Main method 
        /// <summary>
        /// It is the main run method which runs the program, driver code
        /// </summary>
        public void Run()
        {
           
            //  TaskCompleted event
            TaskCompleted += (TaskCompletedEventHandler) => DisplayTaskList();

            while (true)
            {       //Exception Handling
                try
                {
                    Console.Write("Enter task name (or 'exit' to quit): ");
                    string taskName = Console.ReadLine();
                    // If exit is inputted, the program breaks
                    if (taskName.ToLower() == "exit")
                        break;

                    // Task name exception handling 
                    if (string.IsNullOrWhiteSpace(taskName))
                    {
                        throw new ArgumentException("Task name cannot be empty or whitespace.");
                    }
                    // Adding new taskName to list tasks
                    Task newTask = new Task { TaskName = taskName };
                    tasks.Add(newTask);

                    // Display the initial task list
                    DisplayTaskList();

                    Console.Write("Mark task as completed? (y/n): ");
                    string response = Console.ReadLine();

                    // Assigning Completion status to task
                    if (response.ToLower() == "y")
                    {
                        newTask.IsCompletedValue = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
           
           
        }/// <summary>
        /// Printing the specific tasks details which want to be shown
        /// Takes a string input
        /// </summary>
        public void DisplayTask()

        {
            Console.WriteLine("Please enter the task name of which you want to know the details");
            string SpecificTask = Console.ReadLine();
            // Implementing Linq
            var CompletedTasks = tasks.Where(s => s.TaskName.Contains(SpecificTask)).Select(s => new { s.TaskName, s.IsCompletedValue });
            Console.WriteLine("The details are:-");
            foreach (var completedtasks in CompletedTasks) {
             
                    Console.WriteLine($"The task {completedtasks.TaskName} - {(completedtasks.IsCompletedValue ? "Completed" : "Pending")}");
              
            }



        }
    }

   
}

