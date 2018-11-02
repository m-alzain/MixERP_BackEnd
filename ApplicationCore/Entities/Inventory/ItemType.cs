using System;
using System.Collections.Generic;
using ApplicationCore.Entities.Config;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Auth;
using ApplicationCore.Entities.Calendar;
using ApplicationCore.Entities.Purchases;

namespace ApplicationCore.Entities.Inventory
{
    public class ItemType
    {
        public int ItemTypeId { get; set; }
        public string ItemTypeCode { get; set; }
        public string ItemTypeName { get; set; }
        public bool IsComponent { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
