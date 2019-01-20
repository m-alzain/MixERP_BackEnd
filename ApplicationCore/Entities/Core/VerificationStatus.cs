//using ApplicationCore.Entities.Finance;
//using ApplicationCore.Entities.Hrm;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics.Contracts;

//namespace ApplicationCore.Entities.Core
//{
//    public class VerificationStatus
//    {
//        public short VerificationStatusId { get; set; }
//        public string VerificationStatusName { get; set; }
//        public int? AuditUserId { get; set; }
//        public DateTimeOffset? AuditTs { get; set; }
//        public bool? Deleted { get; set; }

//        public ICollection<Hrm.Contract> Contracts { get; set; }
//        public ICollection<Exit> Exits { get; set; }
//        public ICollection<LeaveApplication> LeaveApplications { get; set; }
//        public ICollection<Resignation> Resignations { get; set; }
//        public ICollection<Termination> Terminations { get; set; }
//        public ICollection<TransactionMaster> TransactionMasters { get; set; }
//    }
//}
