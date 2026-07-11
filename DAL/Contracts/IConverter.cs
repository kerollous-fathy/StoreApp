using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL
{
    public interface IConverter<T>
    {
        public string ConvertData(List<T> data);

        public List<T> ConvertBack(string fileData);
    }
}
