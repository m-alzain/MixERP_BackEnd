using ApplicationCore.Entities.Accounts;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Config
{
    public partial class SmtpConfig
    {
        public int SmtpConfigId { get; set; }
        public string ConfigurationName { get; set; }
        public bool Enabled { get; set; }
        public bool IsDefault { get; set; }
        public string FromDisplayName { get; set; }
        public string FromEmailAddress { get; set; }
        public string SmtpHost { get; set; }
        public bool? SmtpEnableSsl { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public int SmtpPort { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
    }
}
