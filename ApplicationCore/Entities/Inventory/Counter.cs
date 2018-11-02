using System;
using System.Collections.Generic;
using ApplicationCore.Entities.Config;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Auth;
using ApplicationCore.Entities.Calendar;
using ApplicationCore.Entities.Purchases;
using ApplicationCore.Entities.Sales;

namespace ApplicationCore.Entities.Inventory
{
    public class Counter
    {
        public int CounterId { get; set; }
        public string CounterCode { get; set; }
        public string CounterName { get; set; }
        public int StoreId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Store Store { get; set; }
        public ICollection<CashierLoginInfo> CashierLoginInfoes { get; set; }
        public ICollection<Cashier> Cashiers { get; set; }
        public ICollection<Return> Returns { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
