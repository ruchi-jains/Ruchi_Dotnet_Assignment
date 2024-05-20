using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruchi_assignment1_updated
{
    

    class Program
    {
        static List<Task> tasks = new List<Task>();

        public static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("\nTask List Menu");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Edit Task Name");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTask();
                        break;
                    case 2:
                        ViewTasks();
                        break;
                    case 3:
                        UpdateTask();
                        break;
                    case 4:
                        DeleteTask();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            } while (choice != 5);
        }

        private static void AddTask()
        {
            Console.Write("Enter task Name (or 'q' to quit): ");
            string Name = Console.ReadLine();
            Console.Write("Enter task Description: ");
            string Description = Console.ReadLine();

            while (!Name.Equals("q", StringComparison.OrdinalIgnoreCase) && string.IsNullOrEmpty(Name))
            {
                Console.WriteLine("Name cannot be empty. Enter task Name (or 'q' to quit): ");
                Name = Console.ReadLine();
            }

            if (!Name.Equals("q", StringComparison.OrdinalIgnoreCase))
            {
                tasks.Add(new Task(Name, Description));
                Console.WriteLine("Task added successfully!");
            }
        }

        private static void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found!");
                return;
            }

            Console.WriteLine("Tasks:");
            int counter = 1; // Use a counter for visual numbering
            foreach (Task task in tasks)
            {
                Console.WriteLine($"{counter++}. {task.Name}    Descripton: {task.Description}");
            }
        }

        private static void UpdateTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found to edit!");
                return;
            }

            ViewTasks();
            Console.Write("Enter the task number to edit (1-{0}): ", tasks.Count);
            int taskIndex; // Use index for modification

            while (!int.TryParse(Console.ReadLine(), out taskIndex) || taskIndex < 1 || taskIndex > tasks.Count)
            {
                Console.WriteLine("Invalid task number. Please enter a number between 1 and {0}:", tasks.Count);
            }

            taskIndex--; // Adjust for 0-based indexing

            Console.Write("Enter new task Name (or 'q' to quit): ");
            string newName = Console.ReadLine();
            Console.Write("Enter new task Description (or 'q' to quit): ");
            string newDescription = Console.ReadLine();

            while (!newName.Equals("q", StringComparison.OrdinalIgnoreCase) && string.IsNullOrEmpty(newName))
            {
                Console.WriteLine("Name cannot be empty. Enter new task Name (or 'q' to quit): ");
                newName = Console.ReadLine();
            }

            if (!newName.Equals("q", StringComparison.OrdinalIgnoreCase))
            {
                tasks[taskIndex].Name = newName;
                tasks[taskIndex].Description = newDescription;
                Console.WriteLine("Task Name and description updated successfully!");
            }
        }

        private static void DeleteTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found to delete!");
                return;
            }

            ViewTasks();
            Console.Write("Enter the task number to delete (1-{0}): ", tasks.Count);
            int taskIndex;

            while (!int.TryParse(Console.ReadLine(), out taskIndex) || taskIndex < 1 || taskIndex > tasks.Count)
            {
                Console.WriteLine("Invalid task number. Please enter a number between 1 and {0}:", tasks.Count);
            }

            taskIndex--; // Adjust for 0-based indexing

            tasks.RemoveAt(taskIndex);
            Console.WriteLine("Task deleted successfully!");
        }
    }

    class Task
    {
        
        public string Name { get; set; }
        public string Description { get; set; }

        public Task(string name, string description)
        {
           
            Name = name;
            Description = description;
        }
    }

}
