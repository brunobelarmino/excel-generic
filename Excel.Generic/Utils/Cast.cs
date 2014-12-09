using System;
using System.Globalization;

namespace Excel.Generic.Utils
{
    internal static class Cast
    {
        internal static DateTime ToDate(string value)
        {
            DateTime dataEntrega = DateTime.Now;
            double dDataEntrega = 0;

            if (double.TryParse(value, out dDataEntrega))
                return System.DateTime.FromOADate(dDataEntrega);
            else
            {
                if (DateTime.TryParse(value, out dataEntrega))
                    return dataEntrega;
                else
                    throw new InvalidCastException("Falha realizar a conversão.");
            }
        }

        internal static object ToType(string value, Type type)
        {
            return Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
        }
    }
}
