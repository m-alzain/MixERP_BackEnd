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
    public class CashierLoginInfo
    {
        public Guid CashierLoginInfoId { get; set; }
        public int? CounterId { get; set; }
        public int? CashierId { get; set; }
        public DateTimeOffset LoginDate { get; set; }
        public bool Success { get; set; }
        public int AttemptedBy { get; set; }
        public string Browser { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AttemptedByNavigation { get; set; }
        public User AuditUser { get; set; }
        public Cashier Cashier { get; set; }
        public Counter Counter { get; set; }
    }
}
