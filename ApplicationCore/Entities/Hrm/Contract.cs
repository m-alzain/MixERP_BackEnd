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
    public class Contract
    {
        public long ContractId { get; set; }
        public int EmployeeId { get; set; }
        public int OfficeId { get; set; }
        public int DepartmentId { get; set; }
        public int? RoleId { get; set; }
        public int? LeaveBenefitId { get; set; }
        public DateTime? BeganOn { get; set; }
        public DateTime? EndedOn { get; set; }
        public int EmploymentStatusCodeId { get; set; }
        public short VerificationStatusId { get; set; }
        public int? VerifiedByUserId { get; set; }
        public DateTime? VerifiedOn { get; set; }
        public string VerificationReason { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Department Department { get; set; }
        public Employee Employee { get; set; }
        public EmploymentStatusCode EmploymentStatusCode { get; set; }
        public LeaveBenefit LeaveBenefit { get; set; }
        public Office Office { get; set; }
        public Role1 Role { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
        public User VerifiedByUser { get; set; }
    }
}
