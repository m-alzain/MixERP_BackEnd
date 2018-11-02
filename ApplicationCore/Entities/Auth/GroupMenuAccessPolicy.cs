using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Core;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Auth
{
    public class GroupMenuAccessPolicy
    {
        public long GroupMenuAccessPolicyId { get; set; }
        public int OfficeId { get; set; }
        public int MenuId { get; set; }
        public int? RoleId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Menu Menu { get; set; }
        public Office Office { get; set; }
        public Role Role { get; set; }
    }
}
