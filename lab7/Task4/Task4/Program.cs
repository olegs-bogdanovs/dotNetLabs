using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        private static ManualResetEvent mre = new ManualResetEvent(false);

        public static void Task1()
        {
            Random random = new Random();
            FileStream fStream = new FileStream(@"./TESTDIR/binarfile.dat", FileMode.Create, FileAccess.ReadWrite, FileShare.None);

            BinaryWriter binaryWriter = new BinaryWriter(fStream);
            for (int i = 0; i < 100; i++)
            {
                int num = random.Next(100);
                Console.Write(num + " ");
                binaryWriter.Write(num);
            }

            fStream.Close();

            Console.WriteLine("");
            Console.WriteLine("Task1: numbers are written to the file.");

            mre.Set();
        }

        public static void Task2()
        {
            mre.WaitOne();
            Console.WriteLine("");
            Console.WriteLine("Task2: StartReading numbers: ");
            FileStream fStream = new FileStream(@"./TESTDIR/binarfile.dat", FileMode.Open, FileAccess.Read, FileShare.Read);

            BinaryReader binaryReader = new BinaryReader(fStream);
            int pos = 0;
            int length = (int)binaryReader.BaseStream.Length;
            while (pos < length)
            {
                int num = binaryReader.ReadInt32();
                Console.Write(num + " ");

                pos += sizeof(int);
            }
            Console.WriteLine("");
            Console.WriteLine("Task2: Data reading finished!");
        }

        public static void Task3()
        {
            mre.WaitOne();
            Console.WriteLine("");
            Console.WriteLine("Task3: Start Sum numbers.");
            FileStream fStream = new FileStream(@"./TESTDIR/binarfile.dat", FileMode.Open, FileAccess.Read, FileShare.Read);

            BinaryReader binaryReader = new BinaryReader(fStream);
            int pos = 0;
            int length = (int)binaryReader.BaseStream.Length;
            int sum = 0;
            while (pos < length)
            {
                sum += binaryReader.ReadInt32();
                pos += sizeof(int);
            }
            Console.WriteLine("");
            Console.WriteLine("Task3: Finished Sum Numbers! Sum=" + sum);
        }

        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"./TESTDIR");
            if (!dir.Exists)
            {
                dir.Create();
            }

            Thread t1 = new Thread(Task1);
            Thread t2 = new Thread(Task2);
            Thread t3 = new Thread(Task3);

            t1.Start();
            t2.Start();
            t3.Start();

            t2.Join();
            t3.Join();

            Console.ReadLine();
        }
    }
}
