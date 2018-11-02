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
    public class Purchase
    {
        public long PurchaseId { get; set; }
        public long CheckoutId { get; set; }
        public int SupplierId { get; set; }
        public int PriceTypeId { get; set; }

        public Checkout Checkout { get; set; }
        public PriceType PriceType { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<PurchaseReturn> PurchaseReturns { get; set; }
    }
}
