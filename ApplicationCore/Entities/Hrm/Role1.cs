using ApplicationCore.Entities.Accounts;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Hrm
{
    public partial class Role1
    {
        public int RoleId { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
