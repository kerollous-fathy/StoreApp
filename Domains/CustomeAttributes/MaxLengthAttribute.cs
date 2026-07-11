using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.CustomeAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLengthAttribute : Attribute
    {
        public int Length { get; }
        public MaxLengthAttribute(int length = 0)
        {
            Length = length;
        }
    }
}
