using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Utilities
{
    public sealed class OrString : IOrString
    {
        public string Get(string s, string or)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return or;
            }

            return s;
        }
    }
}
