using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Sales;
using ApplicationCore.Entities.Purchases;

namespace ApplicationCore.Entities.Inventory
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public int SupplierTypeId { get; set; }
        public int? AccountId { get; set; }
        public string Email { get; set; }
        public string CurrencyCode { get; set; }
        public string CompanyName { get; set; }
        public string PanNumber { get; set; }
        public string CompanyAddressLine1 { get; set; }
        public string CompanyAddressLine2 { get; set; }
        public string CompanyStreet { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyState { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyPoBox { get; set; }
        public string CompanyZipCode { get; set; }
        public string CompanyPhoneNumbers { get; set; }
        public string CompanyFax { get; set; }
        public byte[] Logo { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactMiddleName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactAddressLine1 { get; set; }
        public string ContactAddressLine2 { get; set; }
        public string ContactStreet { get; set; }
        public string ContactCity { get; set; }
        public string ContactState { get; set; }
        public string ContactCountry { get; set; }
        public string ContactPoBox { get; set; }
        public string ContactZipCode { get; set; }
        public string ContactPhoneNumbers { get; set; }
        public string ContactFax { get; set; }
        public byte[] Photo { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public Account Account { get; set; }
        public User AuditUser { get; set; }
        public Currency CurrencyCodeNavigation { get; set; }
        public SupplierType SupplierType { get; set; }
        public ICollection<ItemCostPrice> ItemCostPrices { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<PurchaseReturn> PurchaseReturns { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<SupplierPayment> SupplierPayments { get; set; }
        public ICollection<SupplierwiseCostPrice> SupplierwiseCostPrices { get; set; }
    }
}
