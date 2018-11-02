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
    public class Order1
    {
        public long OrderId { get; set; }
        public long? QuotationId { get; set; }
        public DateTime ValueDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public DateTimeOffset TransactionTimestamp { get; set; }
        public int CustomerId { get; set; }
        public int PriceTypeId { get; set; }
        public int? ShipperId { get; set; }
        public int UserId { get; set; }
        public int OfficeId { get; set; }
        public string ReferenceNumber { get; set; }
        public string Terms { get; set; }
        public string InternalMemo { get; set; }
        public decimal TaxableTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Tax { get; set; }
        public decimal NontaxableTotal { get; set; }
        public bool Cancelled { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Customer Customer { get; set; }
        public Office Office { get; set; }
        public PriceType1 PriceType { get; set; }
        public Quotation1 Quotation { get; set; }
        public Shipper Shipper { get; set; }
        public User User { get; set; }
        public ICollection<OrderDetail1> OrderDetail1 { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
