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
            if (!(item == null || item.Id < 0 || string.IsNullOrEmpty(item.Name) || item.Price < 0 || item.Quantity < 0))
            {
                items.Add(item);
                Console.WriteLine("Item added successfully.");
            }
            else
            {
                Console.WriteLine("make sure your entry is not null or negative");
            }
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
                item.Name = name;
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
            if (item == null  || !int.TryParse(Console.ReadLine(), out id) || id < 1 || id > items.Count)
            {
                Console.WriteLine("please enter valid input");
            }
            else
            {
                
                items.Remove(item);
                Console.WriteLine("Item deleted successfully.");
            }
        }
    }
}
