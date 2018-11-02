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
    public class PriceType1
    {
        public int PriceTypeId { get; set; }
        public string PriceTypeCode { get; set; }
        public string PriceTypeName { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public ICollection<Coupon> CouponAssociatedPriceTypes { get; set; }
        public ICollection<Coupon> CouponForTicketOfPriceTypes { get; set; }
        public ICollection<ItemSellingPrice> ItemSellingPrices { get; set; }
        public ICollection<Order1> Order1 { get; set; }
        public ICollection<Quotation1> Quotation1 { get; set; }
        public ICollection<Return> Returns { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
