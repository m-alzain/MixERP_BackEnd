using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Utilities.Decorators
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class TableNameAttribute : Attribute
    {
        public TableNameAttribute(string tableName)
        {
            this.TableName = tableName;
        }

        public string TableName { get; private set; }
    }
}
