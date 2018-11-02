using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Sales;

namespace ApplicationCore.Entities.Inventory
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public int StoreTypeId { get; set; }
        public int OfficeId { get; set; }
        public int DefaultAccountIdForChecks { get; set; }
        public int DefaultCashAccountId { get; set; }
        public int DefaultCashRepositoryId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Cell { get; set; }
        public bool? AllowSales { get; set; }
        public int SalesDiscountAccountId { get; set; }
        public int PurchaseDiscountAccountId { get; set; }
        public int ShippingExpenseAccountId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Account DefaultAccountIdForChecksNavigation { get; set; }
        public Account DefaultCashAccount { get; set; }
        public CashRepository DefaultCashRepository { get; set; }
        public Office Office { get; set; }
        public Account PurchaseDiscountAccount { get; set; }
        public Account SalesDiscountAccount { get; set; }
        public Account ShippingExpenseAccount { get; set; }
        public StoreType StoreType { get; set; }
        public ICollection<CheckoutDetail> CheckoutDetails { get; set; }
        public ICollection<Counter> Counters { get; set; }
        public ICollection<InventoryTransferDelivery> InventoryTransferDeliveries { get; set; }
        public ICollection<InventoryTransferRequest> InventoryTransferRequests { get; set; }
        public ICollection<SerialNumber> SerialNumbers { get; set; }
    }
}
