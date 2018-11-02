using System;
using System.Collections.Generic;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Inventory;

namespace ApplicationCore.Entities.Purchases
{
    public class OrderDetail
    {
        public long OrderDetailId { get; set; }
        public long OrderId { get; set; }
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
        public Order Order { get; set; }
        public Unit Unit { get; set; }
    }
}
