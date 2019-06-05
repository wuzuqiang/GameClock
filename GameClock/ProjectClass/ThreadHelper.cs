using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameClock.ProjectClass
{
    class ThreadHelper
    {
        private AutoResetEvent exitEvent;
        private Thread thread;
        private int waitTime;
        public ThreadHelper(int time)
        {
            exitEvent = new AutoResetEvent(false);
            waitTime = time;
            thread = new Thread(new ThreadStart(Process));
        }
        public void Run()
        {
            thread.Start();
        }
        public void Stop()
        {
            exitEvent.Set();
            thread.Join();
        }
        private void Process()
        {
            while (true)
            {
                Console.WriteLine("do some thing");
                if (exitEvent.WaitOne(waitTime))
                {
                    break;
                }
            }
        }
    }
}
