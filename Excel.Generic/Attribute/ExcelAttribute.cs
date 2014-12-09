using System;

namespace Excel.Generic.Attribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ExcelAttribute : System.Attribute
    {
        public string Column { get; set; }
    }
}
