using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Hrm
{
    public class Resignation
    {
        public int ResignationId { get; set; }
        public int EnteredBy { get; set; }
        public DateTime NoticeDate { get; set; }
        public DateTime DesiredResignDate { get; set; }
        public int EmployeeId { get; set; }
        public int? ForwardTo { get; set; }
        public string Reason { get; set; }
        public string Details { get; set; }
        public short VerificationStatusId { get; set; }
        public int? VerifiedByUserId { get; set; }
        public DateTime? VerifiedOn { get; set; }
        public string VerificationReason { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Employee Employee { get; set; }
        public User EnteredByNavigation { get; set; }
        public Employee ForwardToNavigation { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
        public User VerifiedByUser { get; set; }
    }
}
