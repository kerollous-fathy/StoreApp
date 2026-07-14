using BL;
using Domains;
using Domains.CustomeAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BL
{
    public class Validator<T> : IValidator<T> where T : BaseEntity
    {
        public bool Validate(T model)
        {
            if (model == null)
                return false;

            if (model.Id <= 0)
                return false;
            Type myType = typeof(T);
            var properties = myType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                if (prop.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                    continue;
                var value = prop.GetValue(model);
                if (prop.PropertyType == typeof(string))
                {
                    var str = value as string;
                    if (string.IsNullOrEmpty(str))
                        return false;
                }
                else if (prop.PropertyType == typeof(int))
                {
                    if (value == null || (int)value < 0)
                        return false;
                }
                else if (prop.PropertyType == typeof(decimal))
                {
                    if (value == null || (decimal)value < 0)
                        return false;
                }
                else if (prop.PropertyType == typeof(double))
                {
                    if (value == null || (double)value < 0)
                        return false;
                }
                else if (prop.PropertyType == typeof(DateTime))
                {
                    if (value == null || (DateTime)value == default)
                        return false;
                }
                // Attribute checks (Addition)
                //Required
                if (Attribute.IsDefined(prop, typeof(RequiredAttribute)))
                {
                    if (value == null)
                        return false;
                    if (prop.PropertyType == typeof(string) && string.IsNullOrEmpty((string)value))
                        return false;
                }
                if (value == null)
                    continue;
                //MinLength / MaxLength / Email / Phone
                if (prop.PropertyType == typeof(string))
                {
                    var str = (string)value;
                    //Min
                    var customMinAttr = prop.GetCustomAttribute<Domains.CustomeAttributes.MinLengthAttribute>();
                    if (customMinAttr == null || str.Length < customMinAttr.Length)
                        return false;

                    //Max
                    var customMaxAttr = prop.GetCustomAttribute<Domains.CustomeAttributes.MaxLengthAttribute>();
                    if (customMaxAttr != null && str.Length > customMaxAttr.Length)
                        return false;

                    //Email
                    if (Attribute.IsDefined(prop, typeof(EmailAttribute)))
                    {
                        var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                        if (!Regex.IsMatch(str, emailPattern))
                            return false;
                    }
                    //Phone
                    var phoneAttr = prop.GetCustomAttribute<PhoneAttribute>();
                    if (phoneAttr != null)
                    {
                        if (!str.All(char.IsDigit))
                            return false;
                        if (phoneAttr.Length > 0 && str.Length != phoneAttr.Length)
                            return false;
                    }
                    //Range
                    var range = prop.GetCustomAttribute<RangeAttribute>();
                    if (range != null)
                    {
                        try
                        {
                            decimal number = Convert.ToDecimal(str);
                            if (number < range.Min || number > range.Max)
                                return false;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
