using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudentCreator.Services
{
    static class Converter
    {
        public static void SetPropertyValue<T>(this object obj, string propertyName, T propertyValue)
            where T : IConvertible
        {
            PropertyInfo pi = obj.GetType().GetProperty(propertyName);

            if (pi != null && pi.CanWrite)
            {
                pi.SetValue
                (
                    obj,
                    Convert.ChangeType(propertyValue, pi.PropertyType),
                    null
                );
            }
        }
    }
}
