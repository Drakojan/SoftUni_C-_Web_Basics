using System;
using System.Collections.Generic;
using System.Text;

namespace exercise_2___Asynchronous_programming
{
    public interface IChronometer
    {
        List<string> Laps { get; }

        string GetTime();

        void Start();
        
        void Stop();

        string Lap();
        
        void Reset();
    }
}
