using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C01_MesClasses.Exceptions
{
    public class TooManyBedsException : Exception
    {
        public TooManyBedsException() : base()
        {
        }

        public TooManyBedsException(string message) : base(message)
        {
        }

        public TooManyBedsException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
