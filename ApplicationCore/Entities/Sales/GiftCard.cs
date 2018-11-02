using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Inventory;
using ApplicationCore.Entities.Purchases;

namespace ApplicationCore.Entities.Sales
{
    public class GiftCard
    {
        public int GiftCardId { get; set; }
        public string GiftCardNumber { get; set; }
        public int PayableAccountId { get; set; }
        public int? CustomerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PoBox { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumbers { get; set; }
        public string Fax { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Customer Customer { get; set; }
        public Account PayableAccount { get; set; }
        public ICollection<GiftCardTransaction> GiftCardTransactions { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
