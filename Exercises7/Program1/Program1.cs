// Author: Maddison Kiefer
// Class: C#
// This program uses three threads to print numbers from 0 to 100 depending on the remainder when dividing by 3.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Program1
{
    class Program1
    {
        static object monitor = new object();
        static int currentNumber = 0;
        public static void Main(string[] args)
        {
            Console.WriteLine("Count From 0 to 100 Using 3 Threads");

            // Create threads
            Thread oneThread = new Thread(Thread0);
            Thread twoThread = new Thread(Thread1);
            Thread threeThread = new Thread(Thread2);

            // Start threads
            oneThread.Start();
            twoThread.Start();
            threeThread.Start();

            // Wait for all threads to complete
            oneThread.Join();
            twoThread.Join();
            threeThread.Join();  
        }

        static void Thread0()
        {
            try
            {
                Monitor.Enter(monitor);
                // Thread0 prints numbers with a remainder of 0 when divided by 3
                for (int i = 0; i <= 100; i += 3)
                {
                    // Wait until it's Thread0's turn to print
                    while (i != currentNumber || i % 3 != 0)
                    {
                        Monitor.Pulse(monitor);
                        Monitor.Wait(monitor);
                    }
                    // Print the number and thread identifier
                    Console.Write(i + ":T0,  ");
                    currentNumber++;
                    // Notify other threads and wait for their turn
                    Monitor.Pulse(monitor);
                    Monitor.Wait(monitor);
                }
            }
            finally
            {
                Monitor.Exit(monitor);
            }
        }

        static void Thread1()
        {
            try
            {
                Monitor.Enter(monitor);
                // Thread1 prints numbers with a remainder of 1 when divided by 3
                for (int i = 1; i <= 100; i += 3)
                {
                    // Wait until it's Thread1's turn to print
                    while (i != currentNumber || i % 3 != 1)
                    {
                        Monitor.Pulse(monitor);
                        Monitor.Wait(monitor);
                    }
                    // Print the number and thread identifier
                    Console.Write(i + ":T1,  ");
                    currentNumber++;
                    // Notify other threads and wait for their turn
                    Monitor.Pulse(monitor);
                    Monitor.Wait(monitor);
                }
            }
            finally
            {
                Monitor.Exit(monitor);
            }
        }

        static void Thread2()
        {
            try
            {
                Monitor.Enter(monitor);
                // Thread2 prints numbers with a remainder of 2 when divided by 3
                for (int i = 2; i <= 100; i += 3)
                {
                    // Wait until it's Thread2's turn to print
                    while (i != currentNumber || i % 3 != 2)
                    {
                        Monitor.Pulse(monitor);
                        Monitor.Wait(monitor);
                    }
                    // Print the number and thread identifier
                    Console.Write(i + ":T2,  ");
                    currentNumber++;
                    // Notify other threads
                    Monitor.Pulse(monitor);

                    // Check if it's the last iteration, reset currentNumber for the next cycle
                    if (i == 100)
                    {
                        currentNumber = 0;
                    }
                    // Wait for other threads' turn
                    Monitor.Wait(monitor);
                }
            }
            finally
            {
                Monitor.Exit(monitor);
            }

            // Print a message indicating that Thread2 has completed its execution
            Console.WriteLine("\n\nDone");
        }
    }
}
