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
    public class Exit
    {
        public long ExitId { get; set; }
        public int EmployeeId { get; set; }
        public int? ForwardTo { get; set; }
        public int ChangeStatusTo { get; set; }
        public int ExitTypeId { get; set; }
        public string ExitInterviewDetails { get; set; }
        public string Reason { get; set; }
        public string Details { get; set; }
        public short VerificationStatusId { get; set; }
        public int? VerifiedByUserId { get; set; }
        public DateTime? VerifiedOn { get; set; }
        public string VerificationReason { get; set; }
        public DateTime ServiceEndDate { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public EmploymentStatus ChangeStatusToNavigation { get; set; }
        public Employee Employee { get; set; }
        public ExitType ExitType { get; set; }
        public Employee ForwardToNavigation { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
        public User VerifiedByUser { get; set; }
    }
}
