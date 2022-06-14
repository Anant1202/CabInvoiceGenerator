using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CustomException : Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDES
        }
        public CustomException(ExceptionType type, string message) : base(message)
        {
            this.type= type;
        }
    }
}
