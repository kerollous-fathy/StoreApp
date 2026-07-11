using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.FileConverters
{
    public class JsonConverter<T> : IConverter<T>
    {
        public List<T> ConvertBack(string fileData)
        {
            return JsonSerializer.Deserialize<List<T>>(fileData);
        }

        public string ConvertData(List<T> data)
        {
            return JsonSerializer.Serialize(data);
        }
    }
}
