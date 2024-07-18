// Author: Maddison Kiefer
// Class: C#
// This program will take input data for a customer and use it to create a customer code. The information
// will be stored and displayed in alphabetical order by last name.

using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerData
{
    // Represents a customer with basic information
    class Customer
    {
        // Full name of the customer
        public string FullName { get; }

        // Date of birth of the customer
        public DateTime Birthdate { get; }

        // Month when the customer subscribed
        public string SubscriptionMonth { get; set; }

        // Zipcode of the customer
        public string ZipCode { get; }

        // Constructor to initialize customer information
        public Customer(string fullName, DateTime birthdate, string subscriptionMonth, string zipCode)
        {
            FullName = fullName;
            Birthdate = birthdate;
            SubscriptionMonth = subscriptionMonth;
            ZipCode = zipCode;
        }
    }

    // Manages a collection of customers and provides operations on them
    class CustomerManager
    {
        // List to store customer data
        private readonly List<Customer> customers = new List<Customer>();

        // Adds a customer to the collection
        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        // Returns customers sorted alphabetically by last name
        public IEnumerable<Customer> GetSortedCustomers()
        {
            return customers.OrderBy(customer => customer.FullName.Split(' ').Last());
        }

        // Generates a customer code based on specific information
        public string GetCustomerCode(Customer customer)
        {
            // Getting information for the customer code
            string lastName = customer.FullName.Split(' ').Last();
            string birthYear = customer.Birthdate.Year.ToString().Substring(2);
            int fullNameLength = customer.FullName.Length;
            string monthAbbreviation = customer.SubscriptionMonth;
            string lastTwoDigitsOfZip = customer.ZipCode.Substring(customer.ZipCode.Length - 2);

            // Format the customer code
            return string.Format("{0}{1}{2:00}{3}{4}", lastName, birthYear, fullNameLength, monthAbbreviation, lastTwoDigitsOfZip);
        }
    }
    class Program
    {
        // Main program to interact with users and display customers
        static void Main()
        {
            CustomerManager customerManager = new CustomerManager();

            Console.WriteLine("Create Customer Codes\n");

            bool addMoreCustomers = true;

            // Loop to add customers
            while (addMoreCustomers)
            {
                Console.Write("Add a customer (y/n): ");
                char response = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (response == 'y')
                {
                    // Prompt user for customer information
                    Console.Write("Enter your first name, space, and then your last name: ");
                    string fullName = Console.ReadLine()!;

                    Console.Write("Enter your Date of Birth in this format: mm/dd/yyyy: ");
                    DateTime birthdate;
                    while (!DateTime.TryParse(Console.ReadLine(), out birthdate))
                    {
                        Console.WriteLine("Invalid date format. Please enter the date in the format mm/dd/yyyy.");
                        Console.Write("Enter your Date of Birth: ");
                    }

                    Console.Write("Enter the month you subscribed: ");
                    string subscriptionMonth = Console.ReadLine()!;
                    
                    Console.Write("Enter your 5-digit zipcode: ");
                    string zipCode;
                    int zipCodeAsInt;

                    while (!int.TryParse(Console.ReadLine(), out zipCodeAsInt) || zipCodeAsInt.ToString().Length != 5)
                    {
                        Console.WriteLine("Invalid zipcode. Please enter a valid 5-digit zipcode.");
                        Console.Write("Enter your 5-digit zipcode: ");
                    }

                    zipCode = zipCodeAsInt.ToString();

                    // Create a new customer
                    Customer customer = new Customer(fullName, birthdate, subscriptionMonth, zipCode);

                    // Add the customer to the manager
                    customerManager.AddCustomer(customer);

                    Console.WriteLine();
                }
                else if (response == 'n')
                {
                    addMoreCustomers = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'");
                }
            }

            // Display mailing label information for all customers, sorted alphabetically by last name
            var sortedCustomers = customerManager.GetSortedCustomers();
            Console.WriteLine("\nMailing Labels Based on Customers in the Database\n");

            // Loop to display mailing label information
            foreach (var customer in sortedCustomers)
            {
                Console.WriteLine("Name: " + customer.FullName);
                Console.WriteLine("DOB: " + string.Format("{0:MM/dd/yyyy}", customer.Birthdate));
                Console.WriteLine("Zip: " + customer.ZipCode);
                Console.WriteLine("Mon: " + customer.SubscriptionMonth);
                Console.WriteLine("CC: " + customerManager.GetCustomerCode(customer));
                Console.WriteLine("\nDone");
            }
        }
    }
}