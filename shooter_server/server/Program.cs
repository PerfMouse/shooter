using System;
using System.Threading;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "server console";
            isRunning = true;

            Thread mainthThread = new Thread(new ThreadStart(MainThread));
            mainthThread.Start();
            
            Server.Start(5, 26950);
        }

        private static bool isRunning = false;

        private static void MainThread()
        {
            Console.WriteLine($"Main thread started. Running at {Constants.TICKS_PER_SEC} ticks per second.");
            DateTime _nextLoop = DateTime.Now;

            while (isRunning)
            {
                while (_nextLoop < DateTime.Now)
                {
                    GameLogic.Update();

                    _nextLoop = _nextLoop.AddMilliseconds(Constants.MS_PER_TICK);

                    if (_nextLoop > DateTime.Now)
                    {
                        Thread.Sleep(_nextLoop - DateTime.Now);
                    }
                }
            }
        }
    }
}