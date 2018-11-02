using ApplicationCore.Entities.Accounts;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Social
{
    public class Feed
    {
        public long FeedId { get; set; }
        public DateTimeOffset EventTimestamp { get; set; }
        public string FormattedText { get; set; }
        public int CreatedBy { get; set; }
        public string Attachments { get; set; }
        public string Scope { get; set; }
        public bool? IsPublic { get; set; }
        public long? ParentFeedId { get; set; }
        public string Url { get; set; }
        public DateTimeOffset AuditTs { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        public int? DeletedBy { get; set; }

        public User CreatedByNavigation { get; set; }
        public User DeletedByNavigation { get; set; }
        public Feed ParentFeed { get; set; }
        public ICollection<Feed> InverseParentFeed { get; set; }
    }
}
