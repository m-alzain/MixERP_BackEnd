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
    public class Coupon
    {
        public int CouponId { get; set; }
        public string CouponName { get; set; }
        public string CouponCode { get; set; }
        public decimal DiscountRate { get; set; }
        public bool IsPercentage { get; set; }
        public decimal? MaximumDiscountAmount { get; set; }
        public int? AssociatedPriceTypeId { get; set; }
        public decimal? MinimumPurchaseAmount { get; set; }
        public decimal? MaximumPurchaseAmount { get; set; }
        public DateTime? BeginsFrom { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public int? MaximumUsage { get; set; }
        public bool? EnableTicketPrinting { get; set; }
        public int? ForTicketOfPriceTypeId { get; set; }
        public decimal? ForTicketHavingMinimumAmount { get; set; }
        public decimal? ForTicketHavingMaximumAmount { get; set; }
        public bool? ForTicketOfUnknownCustomersOnly { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public PriceType1 AssociatedPriceType { get; set; }
        public User AuditUser { get; set; }
        public PriceType1 ForTicketOfPriceType { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
