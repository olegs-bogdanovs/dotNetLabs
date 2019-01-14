using System;

namespace Simple_GC
{
    class Test
    {
        int[] arr = new int[1000000000];
        public void Method(int i)
        {
            //Console.WriteLine(i);
        }
        ~Test()
        {
            //Console.WriteLine("Object " + this.GetHashCode() + "deleted");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tests = new Test[1000];
            try
            {
                for (int i = 0; i < tests.Length; i++)
                {
                    Test test = new Test();
                    tests[i] = test;
                    //test.Method(i);
                }
            }
            catch (OutOfMemoryException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.WriteLine("Heap memory low");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.ReadLine();
        }
    }
}
