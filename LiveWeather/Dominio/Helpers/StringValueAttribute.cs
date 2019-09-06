using System;
using System.Reflection;

namespace Domain.Helpers
{
    public class StringValueAttribute : Attribute
    {
        private string _value;
        public StringValueAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

        public static string GetEnumNameByStringValue<T>(string value)
        {
            Type enumType = typeof(T);
            foreach (Enum val in Enum.GetValues(enumType))
            {
                FieldInfo fi = enumType.GetField(val.ToString());
                StringValueAttribute[] attributes = (StringValueAttribute[])fi.GetCustomAttributes(
                    typeof(StringValueAttribute), false);
                StringValueAttribute attr = attributes[0];
                if (attr.Value == value)
                    return Enum.GetName(typeof(T), val);
            }

            return string.Empty;
        }
    }
}
