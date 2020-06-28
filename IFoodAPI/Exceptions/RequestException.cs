using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFoodAPI.Exceptions
{
    class RequestException : Exception
    {
        public int Code { get; private set; }

        public RequestException(string message, int code): base(message)
        {
            Code = code;
        }

        public RequestException(string message, int code, Exception innerException) : base(message, innerException)
        {
            Code = code;
        }
    }
}
