using System;

namespace Program2
{
    class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Excercise 1 - Marathons - Program 2\n");

            // Creating arrays for hours, minutes and seconds
            var times = new TimeSpan[10];
            int enteredRaces = 0;

            // While the enteredRaces is less than 10, it will continue to ask for times
            while (enteredRaces < 10)
            {
                Console.WriteLine("Please enter the time for race " + (enteredRaces + 1) + " (Format: hh:mm:ss): ");
                var input = Console.ReadLine();

                // If -1 is input to the console, the loop will end
                if (input == "-1")
                {
                    break;
                }

                // Convert and store the input time
                TimeSpan.TryParse(input, out times[enteredRaces]);
                enteredRaces++;
            }

            int fastestIndex = 0;
            int slowestIndex = 0;
            int totalSeconds = 0;

            // Iterate through the input race times and find the fastest and slowest time
            for (int i = 0; i < enteredRaces; i++)
            {
                int timeInSeconds = (int)times[i].TotalSeconds;

                if (timeInSeconds < times[fastestIndex].TotalSeconds)
                {
                    fastestIndex = i;
                }

                if (timeInSeconds > times[slowestIndex].TotalSeconds)
                {
                    slowestIndex = i;
                }

                // Calculates total seconds
                totalSeconds += timeInSeconds;

            }

            // Calculate the average time in seconds
            int averageTimeInSecs = totalSeconds / enteredRaces;
            var averagetime = TimeSpan.FromSeconds(averageTimeInSecs);

            Console.WriteLine();

            // Iterate through entered races to print race info and mark the fastest and slowest races
            for (int i = 0; i < enteredRaces; i++)
            {
                string info = "Race " + (i + 1) + ": " + times[i].Hours + ":" + times[i].Minutes + ":" + times[i].Seconds;

                if (i == fastestIndex)
                {
                    info += " **FASTEST**";
                }

                else if (i == slowestIndex)
                {
                    info += " **SLOWEST**";
                }

                // Display the race info
                Console.WriteLine(info);
            }

            // Display the average time
            Console.WriteLine("\nAverage Time: " + averagetime );
            Console.WriteLine("\nDone");
        }
    }
}