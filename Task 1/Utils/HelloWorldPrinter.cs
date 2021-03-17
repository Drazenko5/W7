using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_1.Utils
{
    public class HelloWorldPrinter
    {
        private readonly int helloIntervalSecond = 1;
        private readonly int worldIntervalSecond = 3;
        private readonly object monitor = new object();

        private bool isStarted = false;

        public void Start()
        {

            lock (monitor)
            {
                if (isStarted)
                    throw new AlreadyStartedException();
                else
                    isStarted = true;
            }


            Task.Run(() => PrintStringInInterval("Hello", helloIntervalSecond));
            Task.Run(() => PrintStringInInterval("World", worldIntervalSecond));

        }

        public void Stop()
        {
            lock (monitor)
            {
                isStarted = false;
            }
        }

        private void PrintStringInInterval(string str, int secontInterval)
        {
            while (true)
            {
                Console.WriteLine(str);
                Thread.Sleep(TimeSpan.FromSeconds(secontInterval));

                lock (monitor)
                {
                    if (!isStarted)
                        return;
                }
            }
        }


    }
}
