using exercise_2___Asynchronous_programming;
using System;

namespace exercise_2_Asynchronous_programming
{
    class Program
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();

            var input = Console.ReadLine();

            while (input!="exit")
            {
                switch (input)
                {
                    case "start":
                        chronometer.Start();
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                    case "lap":
                        Console.WriteLine(chronometer.Lap()); 
                        break;
                    case "laps":
                        var result = "Laps:\r\n";
                        result += string.Join("\r\n",chronometer.Laps);
                        Console.WriteLine(result);
                        break;
                    case "time":
                        Console.WriteLine(chronometer.GetTime());
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                }
                input = Console.ReadLine();
            }

        }
    }
}
