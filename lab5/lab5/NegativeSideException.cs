using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    class NegativeSideException:ApplicationException
    {
        public NegativeSideException() { }
        public NegativeSideException(string message) : base(message) { }
        public NegativeSideException(string message, Exception ex): base(message, ex) { }

    }
}
