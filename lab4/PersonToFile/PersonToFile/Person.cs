using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonToFile
{
    [Serializable]
    class Person
    {
        public int age { get; set; }
        public String perCode { get; set; }
        public String name { get; set; }
    } 
}
