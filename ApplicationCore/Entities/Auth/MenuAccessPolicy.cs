//using ApplicationCore.Entities.Accounts;
//using ApplicationCore.Entities.Core;
//using System;
//using System.Collections.Generic;

//namespace ApplicationCore.Entities.Auth
//{
//    public class MenuAccessPolicy
//    {
//        public long MenuAccessPolicyId { get; set; }
//        public int OfficeId { get; set; }
//        public int MenuId { get; set; }
//        public int? UserId { get; set; }
//        public bool? AllowAccess { get; set; }
//        public bool? DisallowAccess { get; set; }
//        public int? AuditUserId { get; set; }
//        public DateTimeOffset? AuditTs { get; set; }
//        public bool? Deleted { get; set; }

//        public User AuditUser { get; set; }
//        public Menu Menu { get; set; }
//        public Office Office { get; set; }
//        public User User { get; set; }
//    }
//}
