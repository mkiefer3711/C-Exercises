// Author: Maddison Kiefer
// Class: C#
// This program creates a random array and displays the first 10 values and the last 10 values. It displays the minimum and
// maximum values for each thread count as well as the runtime for each.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Program2
{
    class Program
    {
        // Generates an array of unique random integers within a specified range
        private static int[] UniqueRandomArray(int size, int minValue, int maxValue)
        {
            Random rnd = new Random();
            HashSet<int> uniqueNumbers = new HashSet<int>();

            // Continue generating random numbers until reaching the desired array size
            while (uniqueNumbers.Count < size)
            {
                int random_number = rnd.Next(minValue, maxValue + 1);
                uniqueNumbers.Add(random_number);
            }

            return uniqueNumbers.ToArray();
        }

        // Finds the minimum and maximum values within a specific range of the array
        private static (int Min, int Max) FindMinMax(int[] arr, int start, int end)
        {
            int min = arr[start];
            int max = arr[start];

            // Iterate through the specified range to find the min and max values
            for (int i = start + 1; i < end; i++)
            {
                if (arr[i] < min) min = arr[i];
                if (arr[i] > max) max = arr[i];
            }

            return (min, max);
        }

        // Runs the FindMinMax method concurrently using a specified number of threads
        private static void RunWithThreads(int[] arr, int numThreads)
        {
            // Calculate the chunk size for dividing the array among threads
            int chunkSize = arr.Length / numThreads;

            // Start a stopwatch to measure the execution time
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Use an array to store min and max values for each thread
            (int Min, int Max)[] threadResults = new (int, int)[numThreads];

            // Divide the array among threads and find min and max values concurrently
            for (int i = 0; i < numThreads; i++)
            {
                int start = i * chunkSize;
                int end = (i + 1) * chunkSize;
                if (i == numThreads - 1) end = arr.Length;

                threadResults[i] = FindMinMax(arr, start, end);
            }

            // Combine results to get the final min and max
            int min = threadResults.Min(result => result.Min);
            int max = threadResults.Max(result => result.Max);

            // Stop the stopwatch and calculate the elapsed time
            stopwatch.Stop();
            long elapsedTicks = stopwatch.ElapsedTicks;
            double elapsedMilliseconds = (double)elapsedTicks / Stopwatch.Frequency * 1000;

            // Display the results for the specific run
            Console.WriteLine("\nRunning with " + numThreads + " Threads");
            Console.WriteLine("Maximum value in the array is: " + max);
            Console.WriteLine("Minimum value in the array is: " + min);
            Console.WriteLine("Runtime: " + elapsedMilliseconds.ToString("F4") + " ms");
        }

        static void Main(string[] args)
        {
            // Generate an array of unique random numbers
            int[] arr = UniqueRandomArray(10000, 0, 50000);

            // Display the first and last 10 elements of the array
            Console.WriteLine("Threaded Array Minimum and Maximum\n");
            Console.WriteLine("The first 10 values are: \n" + string.Join(", ", arr.Take(10)));
            Console.WriteLine("\nThe last 10 values are: \n" + string.Join(", ", arr.Skip(arr.Length - 10)));

            // Run the program with 2, 10, and 100 threads.
            RunWithThreads(arr, 2);
            RunWithThreads(arr, 10);
            RunWithThreads(arr, 100);

            Console.WriteLine("\nDone");
        }
    }
}
