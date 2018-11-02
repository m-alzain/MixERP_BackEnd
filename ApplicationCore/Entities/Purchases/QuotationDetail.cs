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
    public class QuotationDetail
    {
        public long QuotationDetailId { get; set; }
        public long QuotationId { get; set; }
        public DateTime ValueDate { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal Discount { get; set; }
        public bool IsTaxed { get; set; }
        public decimal ShippingCharge { get; set; }
        public int UnitId { get; set; }
        public decimal Quantity { get; set; }

        public Item Item { get; set; }
        public Quotation Quotation { get; set; }
        public Unit Unit { get; set; }
    }
}
