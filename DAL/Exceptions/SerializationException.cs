using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    public class SerializationException : Exception
    {
        public string CustomMessage { get; set; }
        public SerializationException(string cusmessage) : base()
        {
            CustomMessage = cusmessage;
        }
        public SerializationException(string message, string cusmessage) : base(message)
        {
            CustomMessage = cusmessage;
        }
        public SerializationException(string message, string cusmessage, Exception innerException)
            : base(message, innerException)
        {
            CustomMessage = cusmessage;
        }
    }
}
