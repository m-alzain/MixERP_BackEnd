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
    public class PriceType
    {
        public int PriceTypeId { get; set; }
        public string PriceTypeCode { get; set; }
        public string PriceTypeName { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<Quotation> Quotations { get; set; }
    }
}
