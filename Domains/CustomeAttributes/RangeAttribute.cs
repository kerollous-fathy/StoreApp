using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domains.CustomeAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RangeAttribute : Attribute
    {
        public decimal Min { get; }
        public decimal Max { get; }

        public RangeAttribute(double min , double max)
        {
            Min = (decimal) min;
            Max = (decimal) max;
        }
    }
}
