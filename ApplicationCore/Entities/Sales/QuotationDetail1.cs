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
    public class QuotationDetail1
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
        public Quotation1 Quotation { get; set; }
        public Unit Unit { get; set; }
    }
}
