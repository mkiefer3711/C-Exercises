using System;

namespace Program1 
{
    class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Excercise 1 - Marathons - Program 1\n");

            // Receiving the race time
            Console.WriteLine("Please Enter the Time of the Race (Format: hh:mm:ss): ");
            var timeString = Console.ReadLine();
            TimeSpan.TryParse(timeString, out TimeSpan time);
           
            // Calculating the total time in seconds
            int totalTimeSecs = (int)time.TotalSeconds;

            // Receiving the distance
            Console.Write("What is the distance of the race? ");
            double distance = Convert.ToDouble(Console.ReadLine());

            // Receiving the unit
            Console.Write("Is the distance in miles or kilometers? (mi / km): ");
            var unit = Console.ReadLine();

            // Checks the unit and will convert if necessary
            double distanceInMiles = (unit == "km") ? distance * 0.6214 : distance;
            double distanceInKm = (unit == "mi") ? distance * 1.60934 : distance;

            // Calculates the pace in seconds for kilometers and miles
            double paceInSecPerMile = totalTimeSecs / distanceInMiles;
            double paceInSecPerKm = totalTimeSecs / distanceInKm;

            // Calculates minutes and seconds per kilometer or mile
            double minPerMile = paceInSecPerMile / 60;
            double secPerMile = paceInSecPerMile % 60;
            double minPerKm = paceInSecPerKm / 60;
            double secPerKm = paceInSecPerKm % 60;

            // Displays information to the console
            Console.WriteLine("\nTime: " + time);
            Console.WriteLine("Distance in miles: " + distanceInMiles.ToString("#.#") + "  Distance in km: " + distanceInKm.ToString("#.#"));
            Console.WriteLine("Pace in minutes per mile: " + (int)minPerMile + ":" + secPerMile.ToString("#.") + "  Pace in minutes per km: " + (int)minPerKm + ":" + secPerKm.ToString("#."));
            Console.WriteLine("\nDone");
        }
    }
}