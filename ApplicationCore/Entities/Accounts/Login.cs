using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Finance;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Accounts
{
    public class Login
    {
        public long LoginId { get; set; }
        public int? UserId { get; set; }
        public int? OfficeId { get; set; }
        public string Browser { get; set; }
        public string IpAddress { get; set; }
        public bool? IsActive { get; set; }
        public DateTimeOffset LoginTimestamp { get; set; }
        public string Culture { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Office Office { get; set; }
        public User User { get; set; }
        public ICollection<AccessToken> AccessTokens { get; set; }
        public ICollection<TransactionMaster> TransactionMasters { get; set; }
    }
}
