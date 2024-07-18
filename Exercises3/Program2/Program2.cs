// Author: Maddison Kiefer
// Program for an inventory system for an RPG. Items have their own cost and weight and the program will calculate
// the TotalCount and TotalWeight to display it to the console

using System;

namespace Program2
{
    // Interface to describe the behavior of the container
    public interface IContainer
    {
        // Method to add item to container
        void Add(Item item);
        // Property to get the total count of items in the container
        int TotalCount { get; }
        // Property to get the total weight of items in the container
        double TotalWeight { get; }
    }

    // Abstract class the represents an item
    public abstract class Item
    {
        // Cost of the item
        public double Cost { get; protected set; }
        // Weight of the item
        public double Weight { get; protected set; }
    }

    // Different types of items derived from the Item class
    public class Sword : Item
    {
        public Sword()
        {
            Cost = 50;
            Weight = 10;
        }
    }
    public class Potion : Item
    {
        public Potion()
        {
            Cost = 10;
            Weight = 2;
        }
    }
    public class Bow : Item
    {
        public Bow()
        {
            Cost = 40;
            Weight = 5;
        }
    }
    public class Arrow : Item
    {
        public Arrow()
        {
            Cost = 3;
            Weight = 1;
        }
    }
    public class Staff : Item
    {
        public Staff()
        {
            Cost = 45;
            Weight = 7;
        }
    }

    // BagOfHolding that is both an item and a container
    public class BagOfHolding : Item, IContainer
    {
        // List to hold the items in the bag
        private List<Item> items;
        
        public BagOfHolding(int capacity)
        {
            //Initialize the list with a specific capacity
            items = new List<Item>(capacity);
            // Sets the cost of the bag
            Cost = 100;
            // Sets the weight of the bag
            Weight = 5;
        }
        public void Add(Item item)
        {
            // Add an item to the bag
            items.Add(item);
        }
        public int TotalCount
        {
            get
            {
                // Initialize count with the number of items directly in the bag
                int count = items.Count;
                foreach (var item in items)
                {
                    if (item is IContainer container)
                    {
                        // Recursively add the count of items in contained containers
                        count += container.TotalCount;
                    }
                }
                // Returns the total count
                return count;
            }
        }
        public double TotalWeight
        {
            get
            {
                // Initialize weight with the weight of the bag itself
                double weight = Weight;
                foreach (var item in items)
                {
                    // Add the weight of each item in the bag
                    weight += item.Weight;
                    if (item is IContainer container)
                    {
                        // Recursively add the weight of items in contained containers
                        weight += container.TotalWeight;
                    }
                }
                // Return the total weight
                return weight;
            }
        }
    }

    // Inventory class which is also a container
    public class Inventory : IContainer
    {
        // List to hold the items in the inventory
        private List<Item> items;

        public Inventory(int capacity)
        {
            // Initialize the list with a specified capacity
            items = new List<Item>(capacity);
        }

        public void Add(Item item)
        {
            // Add an item to the inventory
            items.Add(item);
        }

        public int TotalCount
        {
            get
            {
                // Initialize count with the number of items directly in the inventory
                int count = items.Count;
                foreach (var item in items)
                {
                    if (item is IContainer container)
                    {
                        // Recursively add the count of items in contained containers
                        count += container.TotalCount;
                    }
                }
                // Return the total count
                return count;
            }
        }

        public double TotalWeight
        {
            get
            {
                // Initialize weight as zero
                double weight = 0;
                foreach (var item in items)
                {
                    
                    if (item is IContainer container)
                    {
                        // Recursively add the weight of items in contained containers
                        weight += container.TotalWeight;
                    }
                    else
                    {
                        // Add the weight of each item directly in the inventory
                        weight += item.Weight;
                    }
                }
                // Return the total weight
                return weight;
            }
        }
    }

    class Program2
    {
        static void Main(string[] args)
        {
            // Testing the classes
            // Creates the inventory and sets capacity
            var inventory = new Inventory(3);
            // Adds items to the inventory
            inventory.Add(new Sword());
            inventory.Add(new Potion());
            // Creates a new bagOfHolding and sets capacity
            var bagOfHolding = new BagOfHolding(4);
            // Adds the bag to the inventory
            inventory.Add(bagOfHolding);
            // Adds an item to the bag of holding
            bagOfHolding.Add(new Sword());

            Console.WriteLine("Module 3 - Exercise 2 - Inventory\n");
            // Displaying the info the the console
            Console.WriteLine("First Inventory\n");
            Console.WriteLine("Total number of items in Bag: {0}", bagOfHolding.TotalCount);
            Console.WriteLine("Total weight of Bag and items inside: {0} pounds", bagOfHolding.TotalWeight);
            Console.WriteLine();
            Console.WriteLine("The number of items in the inventory is {0}", inventory.TotalCount);
            Console.WriteLine("The total weight of the inventory is {0}", inventory.TotalWeight);

            // Creates the inventory and sets capacity
            var inventory2 = new Inventory(8);
            // Adds items to the inventory
            inventory2.Add(new Sword());
            inventory2.Add(new Staff());
            inventory2.Add(new Bow());
            inventory2.Add(new Potion());
            // Creates a new bagOfHolding and sets capacity
            var bagOfHolding2 = new BagOfHolding(4);
            // Adds the bag to the inventory
            inventory2.Add(bagOfHolding2);
            // Adds items to the bag of holding
            bagOfHolding2.Add(new Arrow());
            bagOfHolding2.Add(new Arrow());
            bagOfHolding2.Add(new Arrow());

            // Displaying the info the the console
            Console.WriteLine("\nSecond Inventory\n");
            Console.WriteLine("Total number of items in Bag: {0}", bagOfHolding2.TotalCount);
            Console.WriteLine("Total weight of Bag and items inside: {0} pounds", bagOfHolding2.TotalWeight);
            Console.WriteLine();
            Console.WriteLine("The number of items in the inventory is {0}", inventory2.TotalCount);
            Console.WriteLine("The total weight of the inventory is {0}", inventory2.TotalWeight);
            Console.WriteLine("\nDone");
        }
    }
}
