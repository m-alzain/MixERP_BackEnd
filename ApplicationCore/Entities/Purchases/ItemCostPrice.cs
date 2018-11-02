using System;
using System.Collections.Generic;
using ApplicationCore.Entities.Config;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Auth;
using ApplicationCore.Entities.Calendar;
using ApplicationCore.Entities.Inventory;

namespace ApplicationCore.Entities.Purchases
{
    public class ItemCostPrice
    {
        public long ItemCostPriceId { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public int? SupplierId { get; set; }
        public int LeadTimeInDays { get; set; }
        public bool IncludesTax { get; set; }
        public decimal Price { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Item Item { get; set; }
        public Supplier Supplier { get; set; }
        public Unit Unit { get; set; }
    }
}
