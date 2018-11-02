using ApplicationCore.Entities.Accounts;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Config
{
    public partial class KanbanDetail
    {
        public long KanbanDetailId { get; set; }
        public long KanbanId { get; set; }
        public short? Rating { get; set; }
        public string ResourceId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Kanban Kanban { get; set; }
    }
}
