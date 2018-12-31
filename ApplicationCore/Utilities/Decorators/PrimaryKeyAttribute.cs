using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Utilities.Decorators
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PrimaryKeyAttribute : Attribute
    {
        public PrimaryKeyAttribute(string primaryKey, bool autoIncrement = true, bool isIdentity = true)
        {
            this.ColumnName = primaryKey;
            this.AutoIncrement = autoIncrement;
            this.IsIdentity = isIdentity;
        }

        public string ColumnName { get; private set; }
        public bool AutoIncrement { get; set; }
        public bool IsIdentity { get; set; }
    }
}
