using System;
using System.Threading;

namespace Task3
{
    class Program
    {
        public static void startApp()
        {
            App app = new App();
            app.Start();
        }

        static void Main(string[] args)
        {
            for (int i=0; i<3; i++)
            {
                Thread th = new Thread(startApp);
                th.Start();
            }
        }
    }
}
