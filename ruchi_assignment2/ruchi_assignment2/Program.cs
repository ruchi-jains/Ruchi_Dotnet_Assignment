using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruchi_assignment2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            while (true) 
                { 
                Console.WriteLine("\nInventory Management System");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Display All Items");
                Console.WriteLine("3. Find Item by ID");
                Console.WriteLine("4. Update Item");
                Console.WriteLine("5. Delete Item");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                case 1:
                        Console.WriteLine("Enter Item ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Item Name ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Item Price: ");
                        double price = double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Item Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());
                        Item item = new Item(id, name, price, quantity);
                        inventory.AddItem(item);
                        break;
                case 2:
                        inventory.DisplayItems();
                        break;
                case 3:
                        Console.WriteLine("Enter Id to search: ");
                        int searchId = int.Parse(Console.ReadLine());
                        Item foundItem = inventory.FindItemById(searchId);
                        if (foundItem != null)
                        {
                            Console.WriteLine("Item found: " + foundItem);
                        }
                        else
                        {
                            Console.WriteLine("Item not found.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter item Id to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new item Name: ");
                        string updateName = Console.ReadLine();
                        Console.WriteLine("Enter new Item Price");
                        double updatePrice = double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new item Quantity: ");
                        int updateQuantity = int.Parse(Console.ReadLine());
                        inventory.UpdateItem(updateId, updateName, updatePrice, updateQuantity); 
                        break;
                case 5:
                        Console.WriteLine("Enter Item ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        inventory.DeleteItem(deleteId);
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
