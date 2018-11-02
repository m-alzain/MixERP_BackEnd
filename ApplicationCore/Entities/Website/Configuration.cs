using ApplicationCore.Entities.Accounts;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Website
{
    public class Configuration
    {
        public int ConfigurationId { get; set; }
        public string DomainName { get; set; }
        public string WebsiteName { get; set; }
        public string Description { get; set; }
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public bool? IsDefault { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
    }
}
