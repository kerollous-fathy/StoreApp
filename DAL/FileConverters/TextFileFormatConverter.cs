using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.FileConverters
{
    public class TextFileFormatConverter<T> : IConverter<T> where T : new()
    {
        public string ConvertData(List<T> data)
        {
            StringBuilder stringBuilder = new StringBuilder();
            // get generic type
            var type= typeof(T);
            // get propertires of generic type
            var propertires= type.GetProperties();
            foreach (var item in data)
            {
                foreach(var prop in propertires)
                {
                    var propName = prop.Name;
                    var propValue = prop.GetValue(item);
                    stringBuilder.AppendLine($"{propName}#{propValue}");
                }
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }

        public List<T> ConvertBack(string fileContent)
        {
            try
            {
                var items = new List<T>();
                if (string.IsNullOrWhiteSpace(fileContent))
                    return items;

                var current = new T();
                bool hasAnyField = false;

                using var reader = new StringReader(fileContent); // handles \r\n, \n, or \r
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    // blank line => end of one item block
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        if (hasAnyField)
                        {
                            items.Add(current);
                            current = new T();
                            hasAnyField = false;
                        }
                        continue;
                    }

                    int hashIndex = line.IndexOf('#');
                    if (hashIndex <= 0 || hashIndex == line.Length - 1)
                        continue;

                    string key = line.Substring(0, hashIndex).Trim();
                    string value = line.Substring(hashIndex + 1); // keep spaces in value

                    var property = typeof(T).GetProperty(key);
                    object? convertedValue = null;

                    switch (property.PropertyType)
                    {
                        case Type t when t == typeof(int):
                            if (int.TryParse(value, out var intValue))
                                convertedValue = intValue;
                            else
                                continue;
                            break;
                        case Type t when t == typeof(decimal):
                            if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var decValue))
                                convertedValue = decValue;
                            else
                                continue;
                            break;
                        case Type t when t == typeof(double):
                            if (double.TryParse(value, out var doubleValue))
                                convertedValue = doubleValue;
                            else
                                continue;
                            break;
                        case Type t when t == typeof(DateTime):
                            if (DateTime.TryParse(value, out var dateValue))
                                convertedValue = dateValue;
                            else
                                continue;
                            break;
                        case Type t when t == typeof(string):
                            convertedValue = value;
                            break;
                        default:
                            continue;
                    }

                    if (property != null && convertedValue != null)
                    {
                        property.SetValue(current, convertedValue);
                        hasAnyField = true;
                    }
                }

                if (hasAnyField)
                    items.Add(current);

                return items;
            }
            catch (Exception ex)
            {
                throw new SerializationException("Error parsing text file content.", ex);
            }
        }
    }
}
