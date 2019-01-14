using System;
using System.Collections.Generic;
using System.Text;

namespace Generation_GC
{
    class Car
    {
        private int speed;
        private string name;
        public Car(string name, int speed)
        {
            this.name = name;
            this.speed = speed;
        }
        public override string ToString()
        {
            return string.Format("{0} speed is {1} Km/h", name, speed);
        }
    }
}
