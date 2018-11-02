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
    public class Shipper
    {
        public int ShipperId { get; set; }
        public string ShipperCode { get; set; }
        public string CompanyName { get; set; }
        public string ShipperName { get; set; }
        public string PoBox { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPoBox { get; set; }
        public string ContactAddressLine1 { get; set; }
        public string ContactAddressLine2 { get; set; }
        public string ContactStreet { get; set; }
        public string ContactCity { get; set; }
        public string ContactState { get; set; }
        public string ContactCountry { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ContactCell { get; set; }
        public string FactoryAddress { get; set; }
        public string PanNumber { get; set; }
        public string SstNumber { get; set; }
        public string CstNumber { get; set; }
        public int AccountId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public Account Account { get; set; }
        public User AuditUser { get; set; }
        public ICollection<Checkout> Checkouts { get; set; }
        public ICollection<Order1> Order1 { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Quotation1> Quotation1 { get; set; }
        public ICollection<Quotation> Quotations { get; set; }
    }
}
