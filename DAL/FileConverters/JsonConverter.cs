using DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.FileConverters
{
    public class JsonConverter<T> : IConverter<T> where T : Domains.BaseEntity, new()
    {
        public List<T> ConvertBack(string fileData)
        {
            try
            {
                return JsonSerializer.Deserialize<List<T>>(fileData);
            }
            catch (System.Text.Json.JsonException ex)
            {
                throw new SerializationException("Error during Converting data from json format.", "", ex);
            }
        }

        public string ConvertData(List<T> data)
        {
            return JsonSerializer.Serialize(data);
        }
    }
}
