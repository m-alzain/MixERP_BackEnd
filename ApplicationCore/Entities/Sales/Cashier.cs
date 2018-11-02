using System;
using System.Collections.Generic;
using ApplicationCore.Entities.Config;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Auth;
using ApplicationCore.Entities.Calendar;
using ApplicationCore.Entities.Inventory;
using ApplicationCore.Entities.Purchases;

namespace ApplicationCore.Entities.Sales
{
    public class Cashier
    {
        public int CashierId { get; set; }
        public string CashierCode { get; set; }
        public string PinCode { get; set; }
        public int AssociatedUserId { get; set; }
        public int CounterId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTill { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AssociatedUser { get; set; }
        public User AuditUser { get; set; }
        public Counter Counter { get; set; }
        public ICollection<CashierLoginInfo> CashierLoginInfoes { get; set; }
    }
}
