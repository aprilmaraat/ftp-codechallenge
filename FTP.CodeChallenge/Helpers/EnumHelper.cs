using System;
using System.Reflection;
using System.ComponentModel;
using System.Linq;

namespace FTP.CodeChallenge
{
    public class EnumHelper
    {
        public static string GetEnumDescription<T>(T value) where T : IComparable, IFormattable, IConvertible
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
