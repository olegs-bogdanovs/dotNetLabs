﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp
{
    class HelloCSharp
    {
        static void Main(string[] args)
        {
            HelloVB.HelloVB hello = new HelloVB.HelloVB();
            hello.Hello();
            Console.WriteLine("Hello from C#");
            Console.ReadLine();
        }
    }
}
