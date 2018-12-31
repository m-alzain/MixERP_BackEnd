using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Utilities
{
    public sealed class EnumConverter : IEnumConverter
    {
        public T ToEnum<T>(string value, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            T result;
            return Enum.TryParse(value, true, out result) ? result : defaultValue;
        }
    }
}
