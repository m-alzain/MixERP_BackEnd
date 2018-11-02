using System;
using System.Collections.Generic;
using ApplicationCore.Entities.Config;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Auth;
using ApplicationCore.Entities.Calendar;
using ApplicationCore.Entities.Inventory;
using ApplicationCore.Entities.Purchases;

namespace ApplicationCore.Entities.Hrm
{
    public class EmploymentStatus
    {
        public int EmploymentStatusId { get; set; }
        public string EmploymentStatusCode { get; set; }
        public string EmploymentStatusName { get; set; }
        public bool IsContract { get; set; }
        public int DefaultEmploymentStatusCodeId { get; set; }
        public string Description { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public EmploymentStatusCode DefaultEmploymentStatusCode { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Exit> Exits { get; set; }
        public ICollection<Termination> Terminations { get; set; }
    }
}
