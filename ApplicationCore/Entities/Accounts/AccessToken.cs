//using System;
//using System.Collections.Generic;

//namespace ApplicationCore.Entities.Accounts
//{
//    public class AccessToken
//    {
//        public Guid AccessTokenId { get; set; }
//        public string IssuedBy { get; set; }
//        public string Audience { get; set; }
//        public string IpAddress { get; set; }
//        public string UserAgent { get; set; }
//        public string Header { get; set; }
//        public string Subject { get; set; }
//        public string TokenId { get; set; }
//        public Guid? ApplicationId { get; set; }
//        public long LoginId { get; set; }
//        public string ClientToken { get; set; }
//        public string Claims { get; set; }
//        public DateTimeOffset CreatedOn { get; set; }
//        public DateTimeOffset ExpiresOn { get; set; }
//        public bool Revoked { get; set; }
//        public int? RevokedBy { get; set; }
//        public DateTimeOffset? RevokedOn { get; set; }
//        public int? AuditUserId { get; set; }
//        public DateTimeOffset? AuditTs { get; set; }
//        public bool? Deleted { get; set; }

//        public Application Application { get; set; }
//        public User AuditUser { get; set; }
//        public Login Login { get; set; }
//        public User RevokedByNavigation { get; set; }
//    }
//}
