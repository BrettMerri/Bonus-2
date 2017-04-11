using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            { //infinite loop
                Console.Clear();
                Console.WriteLine("This application calculates how old you are");
                Console.WriteLine("Input your birthday in the format: MM/DD/YYYY.");

                Console.WriteLine("\nInput birthday below:"); //Prompt for first date
                string ageInput = Console.ReadLine();
                if (!isValidDate(ageInput))
                {
                    continue;
                }

                DateTime firstDate = DateTime.ParseExact(ageInput, "d", null);
                DateTime today = DateTime.Today;

                TimeSpan duration;

                if (firstDate > today)
                {
                    Console.Clear();
                    Console.WriteLine("You're from the future!\n\nPress any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    duration = today - firstDate;
                }

                double totalDaysBetween = duration.Days;

                double yearsBetween = calculateYearsBetween(totalDaysBetween);
                double daysBetween = calculateDaysBetween(totalDaysBetween);

                string output = String.Format("Years: {0}\nDays: {1}", yearsBetween, daysBetween);
                Console.Clear();
                Console.WriteLine(output);
                if (daysBetween == 0)
                {
                    Console.WriteLine("Happy Birthday!");
                }
                Console.ReadKey();
            }
        }
        public static bool isValidDate(string date)
        {
            DateTime temp;
            if (!DateTime.TryParseExact(date, "d",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out temp)) //if user input is in small date format return true
            {
                Console.Clear();
                Console.WriteLine("Error: Invalid date!\n\nPress any key to continue...");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        public static double calculateYearsBetween(double totalDaysBetween)
        {
            double yearsBetween = Math.Floor(totalDaysBetween / 365);
            return yearsBetween;
        }
        public static double calculateDaysBetween(double totalDaysBetween)
        {
            double daysBetween = Math.Floor(totalDaysBetween % 365);
            return daysBetween;
        }
    }
}
