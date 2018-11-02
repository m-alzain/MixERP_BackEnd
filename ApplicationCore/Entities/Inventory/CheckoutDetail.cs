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
    public class CheckoutDetail
    {
        public long CheckoutDetailId { get; set; }
        public long CheckoutId { get; set; }
        public int StoreId { get; set; }
        public DateTime ValueDate { get; set; }
        public DateTime BookDate { get; set; }
        public string TransactionType { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal Discount { get; set; }
        public decimal CostOfGoodsSold { get; set; }
        public bool? IsTaxed { get; set; }
        public decimal ShippingCharge { get; set; }
        public int UnitId { get; set; }
        public decimal Quantity { get; set; }
        public int BaseUnitId { get; set; }
        public decimal BaseQuantity { get; set; }
        public DateTimeOffset? AuditTs { get; set; }

        public Unit BaseUnit { get; set; }
        public Checkout Checkout { get; set; }
        public Item Item { get; set; }
        public Store Store { get; set; }
        public Unit Unit { get; set; }
    }
}
