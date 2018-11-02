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
    public class Checkout
    {
        public long CheckoutId { get; set; }
        public DateTime ValueDate { get; set; }
        public DateTime BookDate { get; set; }
        public long TransactionMasterId { get; set; }
        public DateTimeOffset TransactionTimestamp { get; set; }
        public string TransactionBook { get; set; }
        public decimal? TaxableTotal { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TaxRate { get; set; }
        public decimal? Tax { get; set; }
        public decimal? NontaxableTotal { get; set; }
        public int PostedBy { get; set; }
        public int OfficeId { get; set; }
        public bool Cancelled { get; set; }
        public string CancellationReason { get; set; }
        public int? ShipperId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Office Office { get; set; }
        public User PostedByNavigation { get; set; }
        public Shipper Shipper { get; set; }
        public TransactionMaster TransactionMaster { get; set; }
        public ICollection<CheckoutDetail> CheckoutDetails { get; set; }
        public ICollection<PurchaseReturn> PurchaseReturns { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<Return> Returns { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<SerialNumber> SerialNumbers { get; set; }
    }
}
