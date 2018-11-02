using ApplicationCore.Entities.Accounts;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Website
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public int? MenuId { get; set; }
        public int Sort { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }
        public int? ContentId { get; set; }
        public int? ParentMenuItemId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Content Content { get; set; }
        public Menu1 Menu { get; set; }
        public MenuItem ParentMenuItem { get; set; }
        public ICollection<MenuItem> InverseParentMenuItem { get; set; }
    }
}
