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
    public class PayGrade
    {
        public int PayGradeId { get; set; }
        public string PayGradeCode { get; set; }
        public string PayGradeName { get; set; }
        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary { get; set; }
        public string Description { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
