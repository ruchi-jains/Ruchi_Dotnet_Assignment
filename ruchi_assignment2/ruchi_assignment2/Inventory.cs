using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ruchi_assignment2
{
    public class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }
        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine("Item added successfully.");
        }
        public void DisplayItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("No items in inventory.");
            }
            else
            {
                foreach (Item item in items)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public Item FindItemById(int id)
        {
            foreach (Item item in items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
        public void UpdateItem(int id, string name, double price, int quantity)
        {
            Item item = FindItemById(id);
            if (item != null)
            {
                item.Name = name; // Assuming Item has Name, Price, and Quantity properties
                item.Price = price;
                item.Quantity = quantity;
                Console.WriteLine("Item updated successfully.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        public void DeleteItem(int id)
        {
            Item item = FindItemById(id);
            if (item != null)
            {
                items.Remove(item);
                Console.WriteLine("Item deleted successfully.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
    }
}
