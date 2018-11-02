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
    public class PurchaseReturn
    {
        public long PurchaseReturnId { get; set; }
        public long PurchaseId { get; set; }
        public long CheckoutId { get; set; }
        public int SupplierId { get; set; }

        public Checkout Checkout { get; set; }
        public Purchase Purchase { get; set; }
        public Supplier Supplier { get; set; }
    }
}
