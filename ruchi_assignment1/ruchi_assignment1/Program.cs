using System;
using System.Collections.Generic;


namespace ruchi_assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list1 = new List<string>();

            while (true)
            {
                Console.WriteLine("1. Add task");
                Console.WriteLine("2. Read task");
                Console.WriteLine("3. Update task");
                Console.WriteLine("4. Delete task");
                Console.WriteLine("5. Exit");
                Console.WriteLine(" ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Task: ");
                        string task = Console.ReadLine();
                        list1.Add(task);
                        Console.Clear();
                        Console.WriteLine("Task added successfully");
                        Console.WriteLine(" ");
                        break;
                    case 2:
                        Console.WriteLine("Item in a list ");
                        if (list1.Count > 0)
                        {
                            foreach (string names in list1)
                            {
                                Console.WriteLine(names);
                            }
                        }
                        else
                        {
                            Console.WriteLine("You currently have no tasks in your list");
                        }
                        Console.WriteLine(" ");
                        break;
                    case 3:
                        Console.WriteLine("Enter index of task you want to change(index start with 0)");
                        int index = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter updated task");
                        string upTask = Console.ReadLine();
                        list1[index] = upTask;
                        Console.WriteLine("Item in a list ");
                        if (list1.Count > 0)
                        {
                            foreach (string names in list1)
                            {
                                Console.WriteLine(names);
                            }
                        }
                        else
                        {
                            Console.WriteLine("You currently have no tasks in your list");
                        }
                        Console.WriteLine(" ");
                        break;
                    case 4:
                        if (list1.Count > 0)
                        {
                            Console.Write("Enter the item to remove:");
                            list1.Remove(Console.ReadLine());
                            Console.WriteLine("Item Removed");
                            foreach (string names in list1)
                            {
                                Console.WriteLine(names);
                            }
                        }
                        else
                        {
                            Console.WriteLine("List has no items");
                        }
                        Console.WriteLine(" ");
                        break;
                    case 5:
                        {
                            System.Environment.Exit(0);
                            break;
                        }

                    default:
                        Console.WriteLine("Wrong input");
                        Console.WriteLine(" ");
                        break;
                }
            }
        }
    }
}