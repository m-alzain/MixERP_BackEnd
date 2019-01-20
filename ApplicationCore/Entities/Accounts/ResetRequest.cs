//using System;
//using System.Collections.Generic;

//namespace ApplicationCore.Entities.Accounts
//{
//    public class ResetRequest
//    {
//        public Guid RequestId { get; set; }
//        public int UserId { get; set; }
//        public string Email { get; set; }
//        public string Name { get; set; }
//        public DateTimeOffset RequestedOn { get; set; }
//        public DateTimeOffset ExpiresOn { get; set; }
//        public string Browser { get; set; }
//        public string IpAddress { get; set; }
//        public bool? Confirmed { get; set; }
//        public DateTimeOffset? ConfirmedOn { get; set; }
//        public int? AuditUserId { get; set; }
//        public DateTimeOffset? AuditTs { get; set; }
//        public bool? Deleted { get; set; }

//        public User AuditUser { get; set; }
//        public User User { get; set; }
//    }
//}
