using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ApiQuiz.Logic.TimingService
{
    public class TimerService(int nbQuestions) 
    {
        Stopwatch  timer = new();
        private TimeSpan[] times = new TimeSpan[nbQuestions];
        int _ptr;

        public void Start()
        {
            timer.Start();
        }
        public void Stop()
        {
            times[_ptr] = timer.Elapsed;
            _ptr++;
            timer.Reset();
        }
        public TimeSpan[] GetResult() => times;
    }
}
