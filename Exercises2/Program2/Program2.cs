// Program for displaying and calculating with fractions

using System;

namespace Program2
{
    class Fraction
    {
        // Variables to store the numerator and denominator
        public int Numerator;
        public int Denominator;

        // Constructor to initialize a Fraction object with a given numerator and denominator
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        // Method to convert a fraction to a decimal
        public double ToDecimal()
        {
            return (double)Numerator / Denominator;
        }

        // Method to add a second fraction to this fraction
        public Fraction Add(Fraction f)
        {
            // Calculates numerator and denominator
            Numerator = (Numerator * f.Denominator) + (Denominator * f.Numerator);
            Denominator = Denominator * f.Denominator;
            // Calls the simplify method on the current instance of the Fraction class
            this.Simplify();
            // Returns the current instance of the Fraction object
            return this;
        }

        // Method to multiply a second fraction to this fraction
        public Fraction Multiply(Fraction f)
        {
            // Calculates numerator and denominator
            Numerator = Numerator * f.Numerator;
            Denominator = Denominator * f.Denominator;
            // Calls the simplify method on the current instance of the Fraction class
            this.Simplify();
            // Returns the current instance of the Fraction object
            return this;
        }

        // Method to simplify the fraction by finding the GCD using Euclid's algorithm
        public Fraction Simplify()
        {
            int remainder;
            int numer = Numerator;
            int denom = Denominator;

            // As long as the denominator does not equal zero
            while (denom != 0)
            {
                // Remainder will equal numerator mod denominator
                remainder = numer % denom;
                // Numerator is set equal to denominator
                numer = denom;
                // Denominator is set equal to the remainder
                denom = remainder;
            }
            // Divides the current value of Numerator and Denominator by the GCD stored in the numer value
            Numerator = Numerator / numer;
            Denominator = Denominator / numer;
            return this;
        }


    }
    // Creating another class for testing the Fraction class
    class Program2
    {
        // Main function for testing
        public static void Main(string[] args)
        {
            Console.WriteLine("Module 2 Exercise 2 - Fractions\n");

            // Creating a new Fraction object and converting it to a decimal
            Fraction frac1 = new Fraction(1, 2);
            Console.WriteLine("1/2 = " + frac1.ToDecimal());

            // Creating two new Fraction objects and adding them together
            Fraction frac2 = new Fraction(1, 7);
            Fraction frac3 = new Fraction(1, 5);
            Fraction resultAdd = frac2.Add(frac3);
            Console.WriteLine("1/7 + 1/5 = " + resultAdd.Numerator + "/" + resultAdd.Denominator);

            // Creating three new Fraction objects and multiplying them together
            Fraction frac4 = new Fraction(1, 4);
            Fraction frac5 = new Fraction(2, 3);
            Fraction frac6 = new Fraction(4, 5);
            Fraction resultMult = (frac4.Multiply(frac5)).Multiply(frac6);
            Console.WriteLine("1/4 * 2/3 * 4/5 = " + resultMult.Numerator + "/" + resultMult.Denominator);
            Console.WriteLine("\nDone");
        }
    }
}
