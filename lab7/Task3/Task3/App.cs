using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task3
{

    class App
    {
        private static Mutex mut = new Mutex();

        public void Start()
        {
            mut.WaitOne();
            Console.WriteLine("Starting application");
            Thread.Sleep(1000);
            Console.WriteLine("Stop Application");
            mut.ReleaseMutex();
        }
    }


}
