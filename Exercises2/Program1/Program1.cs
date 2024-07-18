// Program for finding the greatest common divisor of two numbers using Euclid's algorithm

using System;

namespace Program1
{
    class Program1
    {
        // Method for GCD calculation
        int GreatestCommonDivisor(int a, int b)
        {
            int remainder;
            // As long as b does not equal zero
            while (b != 0)
            {
                // Remainder will equal a mod b
                remainder = a % b;
                // a is set equal to b
                a = b;
                // b is set equal to the remainder
                b = remainder;
            }
            // If b does equal zero, returns a
            return a;
        }

        // Main function for testing
        public static void Main(string[] args)
        {
            // Creating a new instance of the class
            Program1 program1 = new Program1();

            // Calls the method to calculate the GCD of two sets of numbers
            var test1 = program1.GreatestCommonDivisor(164, 410);
            var test2 = program1.GreatestCommonDivisor(87801, 1469);

            // Prints the results to the console
            Console.WriteLine("Module 2 Exercise 2 - GCD\n");
            Console.WriteLine("GreatestCommonDivisor(164, 410) = " + test1);
            Console.WriteLine("GreatestCommonDivisor(87801, 1469) = " + test2);
            Console.WriteLine("\nDone");
        }
    }
}
