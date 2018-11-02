using ApplicationCore.Entities.Accounts;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Auth
{
    public class AccessType
    {
        public int AccessTypeId { get; set; }
        public string AccessTypeName { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public ICollection<EntityAccessPolicy> EntityAccessPolicies { get; set; }
        public ICollection<GroupEntityAccessPolicy> GroupEntityAccessPolicies { get; set; }
    }
}
