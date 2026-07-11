using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Exceptions
{
    public class BusinessException: Exception
    {
        public string CustomMessage { get; set; }
        public BusinessException(string cusmessage) : base()
        {
            CustomMessage = cusmessage;
        }
        public BusinessException(string message, string cusmessage) : base(message)
        {
            CustomMessage = cusmessage;
        }
        public BusinessException(string message, string cusmessage, Exception innerException)
            : base(message, innerException)
        {
            CustomMessage = cusmessage;
        }
    }
}
