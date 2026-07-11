using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Exceptions
{
    public class ValidationException : Exception
    {
        public string CustomMessage { get; set; }
        public ValidationException(string cusmessage) : base()
        {
            CustomMessage = cusmessage;
        }
        public ValidationException(string message, string cusmessage) : base(message)
        {
            CustomMessage = cusmessage;
        }
        public ValidationException(string message, string cusmessage, Exception innerException)
            : base(message, innerException)
        {
            CustomMessage = cusmessage;
        }
    }
}
