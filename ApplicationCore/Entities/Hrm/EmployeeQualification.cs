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
    public class EmployeeQualification
    {
        public long EmployeeQualificationId { get; set; }
        public int EmployeeId { get; set; }
        public int EducationLevelId { get; set; }
        public string Institution { get; set; }
        public string Majors { get; set; }
        public int? TotalYears { get; set; }
        public decimal? Score { get; set; }
        public DateTime? StartedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public string Details { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public Employee Employee { get; set; }
    }
}
