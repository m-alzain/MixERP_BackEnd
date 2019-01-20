//using System;
//using System.Collections.Generic;
//using ApplicationCore.Entities.Accounts;
//using ApplicationCore.Entities.Core;

//namespace ApplicationCore.Entities.Finance
//{
//    public class JournalVerificationPolicy
//    {
//        public int JournalVerificationPolicyId { get; set; }
//        public int UserId { get; set; }
//        public int OfficeId { get; set; }
//        public bool CanVerify { get; set; }
//        public decimal VerificationLimit { get; set; }
//        public bool CanSelfVerify { get; set; }
//        public decimal SelfVerificationLimit { get; set; }
//        public DateTime EffectiveFrom { get; set; }
//        public DateTime EndsOn { get; set; }
//        public bool IsActive { get; set; }
//        public int? AuditUserId { get; set; }
//        public DateTimeOffset? AuditTs { get; set; }
//        public bool? Deleted { get; set; }

//        public User AuditUser { get; set; }
//        public Office Office { get; set; }
//        public User User { get; set; }
//    }
//}
