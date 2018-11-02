using ApplicationCore.Entities.Accounts;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Config
{
    public class CustomFieldDataType
    {
        public string DataType { get; set; }
        public string UnderlyingType { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public ICollection<CustomFieldSetup> CustomFieldSetups { get; set; }
    }
}
