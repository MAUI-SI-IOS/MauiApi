using System.Diagnostics;

namespace ApiQuiz.Logic.TimingService
{
    internal class TimerService: ISubject
    {
        Stopwatch  timer = new();
        private TimeSpan[] times = [];
        int _ptr;

        public void Start()
        {
            timer.Start();
        }
        public void Update()
        {
            times[_ptr] = timer.Elapsed;
            _ptr++;
            timer.Reset();
        }
        public TimeSpan[] GetResult() => times;
    }
}
