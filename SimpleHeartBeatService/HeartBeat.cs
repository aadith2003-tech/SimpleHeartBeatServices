using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SimpleHeartBeatService
{
    public class HeartBeat
    {
        private readonly System.Timers.Timer _timer;

        public HeartBeat()
        {
            _timer=new System.Timers.Timer(1000) { AutoReset= true };
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[]
            {DateTime.Now.ToString() };
            File.AppendAllLines(@"C:\Temp\Demos\HeartBeat.txt",lines);
        }
          
        public void Start()
        {
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }
    }
}
