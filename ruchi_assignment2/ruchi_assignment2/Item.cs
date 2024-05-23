using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruchi_assignment2
{
    public class Item
    {
        private int id;
        private string name;
        private double price;
        private int quantity;

        public Item(int id, string name, double price, int quantity)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

      
         public int Id
         {
             get { return id; }
             private set { id = value; }   //Encapsulation
         }

         public string Name
         {
             get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) == true)
                {
                    Console.WriteLine("Name cannot be null or empty");
                }
                else
                {
                    name = value;
                }
            }
        }

         public double Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Price must be greater than zero.");
                }
                else 
                { 
                    price = value;
                }
            }
         }

         public int Quantity
         {
             get { return quantity; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Quantity cannot be negative.");
                }
                else
                {
                    quantity = value;
                }
            }
         }

        public override string ToString()
        {
            return $"Item [ID={id}, Name={name}, Price={price}, Quantity={quantity}]";
        }
    }
}



