using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace exercise_2___Asynchronous_programming
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;

        public Chronometer()
        {
            this.stopwatch = new Stopwatch();
            this.Laps = new List<string>();
        }

        public List<string> Laps { get; }

        public string GetTime()
        {
            return this.stopwatch.Elapsed.ToString();
        } 

        public string Lap()
        {
            var newLap = GetTime();
            Laps.Add(newLap);

            return newLap;
        }

        public void Reset()
        {
            stopwatch.Reset();
            Laps.Clear();
        }

        public void Start()
        {
            this.stopwatch.Start();
        }

        public void Stop()
        {
            this.stopwatch.Stop();
        }
    }
}
