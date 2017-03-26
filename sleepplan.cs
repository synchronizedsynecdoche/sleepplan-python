using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sleepplan {
    class sleepplan {

        public DateTime[] wakeupTimes = new DateTime[6];
        public DateTime bedtime;
        public String response = null;
        public int offset = 15;
        int parseSuccess;
        bool endTest;

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
            endTest = int.TryParse(response, out parseSuccess);
            if (endTest) {
                offset = Int32.Parse(response);
            } else {
                Console.WriteLine("Offset was not changed because input was not an integer.");
                return;
            }
        }

        public void Menu (ref String response) {

            // Response Cleaning
            response = response.Replace("-", "");
            if (response.Contains("o")) {
                response = response.Replace("o", "");
                ChangeOffset();
            }

            //Menu Options
            switch (response) {
                case "l":
                    Console.WriteLine("Please insert a bedtime. Format: 12:30 AM");
                    response = Console.ReadLine();
                    endTest = DateTime.TryParse(response, out bedtime);
                    if (endTest) {
                        DateTime bedtime = DateTime.Parse(response);
                    } else {
                        Console.WriteLine("Bedtime was not set because format was incorrect.");
                        Console.WriteLine();
                        Console.Write(">");
                        response = Console.ReadLine();
                        Menu(ref response);
                        return;
                    }
                    ConsoleColor oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("If you are going to bed at {0:t}, wake up at", bedtime);
                    for (int i = 0; i < wakeupTimes.Length; i++) {
                        wakeupTimes[i] = bedtime.AddMinutes(offset + ((i + 1) * 90));
                        double hoursOfSleep = (i + 1) * 1.5;
                        Console.WriteLine("{0:t} for {1} hours of sleep", wakeupTimes[i], hoursOfSleep);
                    }
                    Console.ForegroundColor = oldColor;
                    Console.WriteLine();
                    Console.Write(">");
                    response = Console.ReadLine();
                    Menu(ref response);
                    return;
                case "b":
                    Console.WriteLine("Please insert a wakeup time. Format: 12:30 AM");
                    response = Console.ReadLine();
                    DateTime wakeupTime = new DateTime();
                    endTest = DateTime.TryParse(response, out wakeupTime);
                    if (endTest) {
                        wakeupTime = DateTime.Parse(response);
                    } else {
                        Console.WriteLine("Wakeup time was not set because format was incorrect.");
                        Console.WriteLine();
                        Console.Write(">");
                        response = Console.ReadLine();
                        Menu(ref response);
                        return;
                    }
                    oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("If you are waking up at {0:t}, go to bed at", wakeupTime);
                    for (int i = 0; i < wakeupTimes.Length; i++) {
                        wakeupTimes[i] = wakeupTime.AddMinutes(-offset - ((i + 1) * 90));
                        double hoursOfSleep = (i + 1) * 1.5;
                        Console.WriteLine("{0:t} for {1} hours of sleep", wakeupTimes[i], hoursOfSleep);
                    }
                    Console.ForegroundColor = oldColor;
                    Console.WriteLine();
                    Console.Write(">");
                    response = Console.ReadLine();
                    Menu(ref response);
                    return;
                case "":
                    WakeupTimes();
                    Console.WriteLine();
                    Console.Write(">");
                    response = Console.ReadLine();
                    Menu(ref response);
                    return;
                case "h":
                    Console.WriteLine(@"To change fall asleep offset, use ""o"".");
                    Console.WriteLine(@"If you are going to bed later, use ""l"".");
                    Console.WriteLine(@"If you need to get up at a certain time, use ""b"" to find bedtimes.");
                    Console.WriteLine(@"These can also be passed as arguments.");
                    Console.WriteLine(@"Finally, use ""e"" to exit.");
                    Console.WriteLine();
                    Console.Write(">");
                    response = Console.ReadLine();
                    Menu(ref response);
                    return;
                case "e":
                    Environment.Exit(0);
                    return;
            }
            Console.WriteLine("Invalid selection, please try again");
            Console.WriteLine();
            Console.Write(">");
            response = Console.ReadLine();
            Menu(ref response);
    }

        static void Main(string[] args) {
            sleepplan sleepplan = new sleepplan();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Title = "sleepplan";
            Console.WriteLine("Welcome to sleepplan.");
            Console.WriteLine("The current time is {0:t}", DateTime.Now);
            if (args.Length == 0) {
                Console.WriteLine("To view help, type \"h\"\n");
                sleepplan.WakeupTimes();
                Console.Write(">");
                String response = Console.ReadLine();
                sleepplan.Menu(ref response);
            } else {
                String response = string.Concat(args);
                sleepplan.Menu(ref response);
            }

        }
    }
}
