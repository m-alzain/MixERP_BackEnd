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
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public int CustomerTypeId { get; set; }
        public int? AccountId { get; set; }
        public string Email { get; set; }
        public string CurrencyCode { get; set; }
        public string CompanyName { get; set; }
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
        public CustomerType CustomerType { get; set; }
        public ICollection<CustomerReceipt> CustomerReceipts { get; set; }
        public ICollection<CustomerwiseSellingPrice> CustomerwiseSellingPrices { get; set; }
        public ICollection<GiftCard> GiftCards { get; set; }
        public ICollection<LateFeePosting> LateFeePostings { get; set; }
        public ICollection<Order1> Order1 { get; set; }
        public ICollection<Quotation1> Quotation1 { get; set; }
        public ICollection<Quotation> Quotations { get; set; }
        public ICollection<Return> Returns { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
