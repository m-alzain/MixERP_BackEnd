using ApplicationCore.Entities.Accounts;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Config
{
    public partial class SmsQueue
    {
        public long QueueId { get; set; }
        public string ApplicationName { get; set; }
        public string FromName { get; set; }
        public string FromNumber { get; set; }
        public string Subject { get; set; }
        public string SendTo { get; set; }
        public string Message { get; set; }
        public DateTimeOffset AddedOn { get; set; }
        public DateTimeOffset SendOn { get; set; }
        public bool Delivered { get; set; }
        public DateTimeOffset? DeliveredOn { get; set; }
        public bool Canceled { get; set; }
        public DateTimeOffset? CanceledOn { get; set; }
        public bool IsTest { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
    }
}
