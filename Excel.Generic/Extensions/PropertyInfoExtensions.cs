using Excel.Generic.Utils;
using System;
using System.Reflection;

namespace Excel.Generic.Extensions
{
    internal static class PropertyInfoExtensions
    {
        internal static void SetValue(this PropertyInfo property, object item, string value)
        {
            Type propertyType = property.PropertyType;
            string propertyName = property.Name;

            try
            {
                var val = propertyType.Name.Equals("DateTime") ? Cast.ToDate(value) : Cast.ToType(value, propertyType);
                property.SetValue(item, val);
            }
            catch (Exception)
            {
                throw new InvalidCastException(string.Format("Falha realizar a conversão do campo {0}", propertyName));
            }
        }
    }
}
