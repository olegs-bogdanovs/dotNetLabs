using System;
using System.Threading;

namespace Generation_GC
{
    class Program
    {
        private static void ShowGCStat()
        {
            Console.WriteLine("Generation 0 checked {0} time(s)",
            GC.CollectionCount(0));
            Console.WriteLine("Generation 1 checked {0} time(s)",
            GC.CollectionCount(1));
            Console.WriteLine("Generation 2 checked {0} time(s)",
            GC.CollectionCount(2));
        }


        static void Main(string[] args)
        {
            Thread.Sleep(4000);
            Console.WriteLine("Heap memory size in bytes : {0}",
            GC.GetTotalMemory(false));
            Console.WriteLine("System supports {0} generations",
            GC.MaxGeneration + 1);

            Car car = new Car("Volvo", 120);
            Console.WriteLine(car.ToString());
            Console.WriteLine("Object car relates to {0} generation",
            GC.GetGeneration(car));
            Console.WriteLine("Heap memory size in bytes : {0}",
            GC.GetTotalMemory(false));

            object[] arr = new object[10000000];
            ShowGCStat();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = new object();

            Console.WriteLine("Heap memory size in bytes : {0}",
            GC.GetTotalMemory(false));
            arr = null;

            Console.WriteLine("Array is created, start GC");
            ShowGCStat();

            var start = DateTime.Now;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("GC worked " + (DateTime.Now -
            start).Milliseconds);
            Console.WriteLine("Heap memory size in bytes : {0}",
            GC.GetTotalMemory(false));
            Console.WriteLine("Object car relates to {0} generation",
            GC.GetGeneration(car));
            ShowGCStat();

            Console.ReadLine();        }
    }
}
