using ApplicationCore.Entities.Accounts;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Calendar
{
    public partial class Event
    {
        public Guid EventId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTimeOffset StartsAt { get; set; }
        public DateTimeOffset EndsOn { get; set; }
        public string TimeZone { get; set; }
        public bool AllDay { get; set; }
        public string Recurrence { get; set; }
        public DateTimeOffset? Until { get; set; }
        public int? Alarm { get; set; }
        public string ReminderTypes { get; set; }
        public bool? IsPrivate { get; set; }
        public string Url { get; set; }
        public string Note { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Category1 Category { get; set; }
        public User User { get; set; }
    }
}
