using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Utilities
{
    public interface IEnumConverter
    {
        T ToEnum<T>(string value, T defaultValue) where T : struct;
    }
}
