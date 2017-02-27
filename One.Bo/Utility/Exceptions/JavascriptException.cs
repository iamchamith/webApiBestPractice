using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Bo.Utility.Exceptions
{
    public class JavascriptException : Exception
    {
        public JavascriptException() : base() { }
        public JavascriptException(string message) : base(message) { }
    }
}
