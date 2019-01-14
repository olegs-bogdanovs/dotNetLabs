using System;
using System.Threading;

namespace WorkWithPool
{
    class Program
    {
        static void Task1(Object state)
        {
            Thread.CurrentThread.Name = "1";
            Console.WriteLine("Thread {0}:{1}", Thread.CurrentThread.Name,
            Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();
            Thread.Sleep(200);
        }
        static void Task2(Object state)
        {
            Thread.CurrentThread.Name = "2";
            Console.WriteLine("Thread {0}:{1}", Thread.CurrentThread.Name,
            Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(200);
        }

        public static void ShowThreadInfo()
        {
            int worker = 0;
            int io = 0;
            ThreadPool.GetAvailableThreads(out worker, out io);

            Console.WriteLine("Worker threads: \t\t{0}", worker);
            Console.WriteLine("Asynchronous I/O threads: \t{0}", io);

            int workerThreads;
            int portThreads;

            ThreadPool.GetMaxThreads(out workerThreads, out portThreads);
            Console.WriteLine("Maximum worker threads: \t{0}" +
                "\nMaximum completion port threads: {1}", workerThreads, portThreads);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\nStart program");
            ShowThreadInfo();
            Console.WriteLine("Starting Task1 from thread pool");
            ThreadPool.QueueUserWorkItem(new WaitCallback(Task1));
            ShowThreadInfo();
            Console.WriteLine("Starting Task2 from thread pool");
            Thread.Sleep(1000);
            ThreadPool.QueueUserWorkItem(Task2);
            ShowThreadInfo();
            Console.WriteLine("Main thread.");
            Thread.Sleep(1000);
            Console.WriteLine("Main thread finished.\n");
            Console.WriteLine("Task1 and Task2 finished.");
            ShowThreadInfo();
            Console.ReadKey();

            Console.ReadLine();
        }
    }
}
