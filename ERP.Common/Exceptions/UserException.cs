using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.Exceptions
{
    public class UserException : Exception
    {
        public UserException()
        { }

        public UserException(string message)
            :base(message)
        { }
        public UserException(string exception, Exception inner)
            :base (exception, inner)
        { }
    }
}
