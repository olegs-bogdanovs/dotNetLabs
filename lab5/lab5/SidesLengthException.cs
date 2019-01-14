using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    class SidesLengthException:ApplicationException
    {
        public SidesLengthException() { }
        public SidesLengthException(string message) : base(message) { }
        public SidesLengthException(string message, Exception ex) : base(message, ex) { }

    }
}
