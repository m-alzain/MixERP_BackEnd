using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Utilities.Decorators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreAttribute : Attribute
    {
    }
}
