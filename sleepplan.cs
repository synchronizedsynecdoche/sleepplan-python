using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sleepplan {
    class sleepplan {

        public DateTime[] wakeupTimes = new DateTime[6];
        public String response = null;
        public int offset = 15;

        public void WakeupTimes() { // Generate & Print Wakeup Times
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("If you are going to bed now, wake up at");
            for (int i = 0; i < wakeupTimes.Length; i++) {
                wakeupTimes[i] = DateTime.Now.AddMinutes(offset + ((i + 1) * 90));
                double hoursOfSleep = (i + 1) * 1.5;
                Console.WriteLine("{0:t} for {1} hours of sleep", wakeupTimes[i], hoursOfSleep);
            }
            Console.ForegroundColor = oldColor;
        }

        public void ChangeOffset() { // Change Offset
            Console.WriteLine("\nPlease type an integer to change the fall asleep offset.");
            response = Console.ReadLine();
            int parseSuccess;
            bool endTest = int.TryParse(response, out parseSuccess);
            if (endTest) {
                offset = Int32.Parse(response);
            } else {
                Console.WriteLine("Offset was not changed because input was not an integer.");
                return;
            }
        }

        public void Menu (ref String response) {

            if (response.Contains("o")) {
                response = response.Replace("o", "");
                ChangeOffset();
            }
            response = response.Replace("-", "");
            switch (response) {
                case "l":
                    Console.WriteLine("Please insert a bedtime. Format: 12:30 AM");
                    DateTime bedtime = DateTime.Parse(Console.ReadLine());
                    ConsoleColor oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("If you are going to bed at {0:t}, wake up at", bedtime);
                    for (int i = 0; i < wakeupTimes.Length; i++) {
                        wakeupTimes[i] = bedtime.AddMinutes(offset + ((i + 1) * 90));
                        double hoursOfSleep = (i + 1) * 1.5;
                        Console.WriteLine("{0:t} for {1} hours of sleep", wakeupTimes[i], hoursOfSleep);
                    }
                    Console.ForegroundColor = oldColor;
                    Console.ReadLine();
                    break;
                case "b":
                    Console.WriteLine("Please insert a wakeup time. Format: 12:30 AM");
                    DateTime wakeupTime = DateTime.Parse(Console.ReadLine());
                    oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("If you are waking up at {0:t}, go to bed at", wakeupTime);
                    for (int i = 0; i < wakeupTimes.Length; i++) {
                        wakeupTimes[i] = wakeupTime.AddMinutes(-offset - ((i + 1) * 90));
                        double hoursOfSleep = (i + 1) * 1.5;
                        Console.WriteLine("{0:t} for {1} hours of sleep", wakeupTimes[i], hoursOfSleep);
                    }
                    Console.ForegroundColor = oldColor;
                    Console.ReadLine();
                    break;
                case "":
                    WakeupTimes();
                    Console.ReadLine();
                    break;
            }
        }

        static void Main(string[] args) {
            sleepplan sleepplan = new sleepplan();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Title = "sleepplan";
            Console.WriteLine("Welcome to sleepplan.");
            Console.WriteLine("The current time is {0:t}\n", DateTime.Now);
            if (args.Length == 0) {
                Console.WriteLine("Press enter to generate wakeup times.");
                Console.WriteLine(@"To change fall asleep offset, use ""o"".");
                Console.WriteLine(@"If you are going to bed later, use ""l"".");
                Console.WriteLine(@"If you need to get up at a certain time, use ""b"" to find bedtimes.");
                Console.WriteLine(@"These can also be passed as arguments.");
                String response = Console.ReadLine();
                sleepplan.Menu(ref response);
            } else {
                String response = string.Concat(args);
                sleepplan.Menu(ref response);
            }
        }
    }
}
