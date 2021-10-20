using System;
using System.Linq;
using TalkingClockApp.Services;

namespace TalkingClockApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //If a user has supplied a time...
            if (args.Any())
            {
                Console.WriteLine(Converters.TextNumbersToText(args));
            }
            //otherwise use the time now
            else
            {
                var currentDateTime = DateTime.Now;
                Console.WriteLine(Converters.NumberMinutesToText(currentDateTime));
            }

            Console.Write($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
