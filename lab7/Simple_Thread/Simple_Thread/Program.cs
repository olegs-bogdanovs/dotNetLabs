using System;
using System.Threading;

namespace Simple_Thread
{
    class Program
    {
        static object lockObj = new object();

        public static void Function()
        {
            for (int i = 1; i <= 100; i++)
            {
                lock (lockObj)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(i);
                }
            }
        }

        static void Main(string[] args)
        {

            Thread th = new Thread(Function);
            th.Start();

            for (int i = 1; i <= 100; i++)
            {
                lock (lockObj)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(i);
                }
            }

            th.Join();

            Console.ReadLine();
        }
    }
}
