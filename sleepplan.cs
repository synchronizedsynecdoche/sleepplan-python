using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sleepplan {
    class Program {

        static void GenerateWakeupTimes(ref DateTime[] wakeupTimes, ref int offset) {
            for (int i = 0; i < wakeupTimes.Length; i++) {
                wakeupTimes[i] = DateTime.Now.AddMinutes(offset + ((i + 1) * 90));
            }
        }

        static void PrintWakeupTimes(ref DateTime[] wakeupTimes) {
            for (int i = 0; i < wakeupTimes.Length; i++) {
                ConsoleColor oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Magenta;
                double hoursOfSleep = (i + 1) * 1.5;
                Console.Write("\n{0:t} for {1} hours of sleep", wakeupTimes[i], hoursOfSleep);
                Console.ForegroundColor = oldColor;
            }
        }

        static void ParseOffset(ref DateTime[] wakeupTimes, ref String response, ref int offset) {
            Console.WriteLine("\nIf you want to change the fall-asleep offset from 15 minutes, please type an integer.");
            Console.WriteLine("Otherwise, hit any key to exit.");
            response = Console.ReadLine();
            int parseSuccess;
            bool endTest = int.TryParse(response, out parseSuccess);
            if (endTest) {
                offset = Int32.Parse(response);
                GenerateWakeupTimes(ref wakeupTimes, ref offset);
                PrintWakeupTimes(ref wakeupTimes);
                ParseOffset(ref wakeupTimes, ref response, ref offset);
            } else {
                Environment.Exit(0);
            }
        }

        static void Main(string[] args) {

            DateTime[] wakeupTimes = new DateTime[6];
            String response = "";
            int offset = 15;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Title = "sleepplan";
            Console.WriteLine("Welcome to sleepplan.");
            GenerateWakeupTimes(ref wakeupTimes, ref offset);
            Console.WriteLine("The current time is {0:t}", DateTime.Now);
            Console.Write("If you are going to bed now, wake up at");
            PrintWakeupTimes(ref wakeupTimes);
            ParseOffset(ref wakeupTimes, ref response, ref offset);
        }
    }
}
