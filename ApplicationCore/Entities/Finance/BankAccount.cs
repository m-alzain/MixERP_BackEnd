using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Purchases;
using ApplicationCore.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Finance
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public string BankAccountName { get; set; }
        public int? AccountId { get; set; }
        public int MaintainedByUserId { get; set; }
        public int BankTypeId { get; set; }
        public bool IsMerchantAccount { get; set; }
        public int OfficeId { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankContactNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankAccountType { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Cell { get; set; }
        public string RelationshipOfficerName { get; set; }
        public string RelationshipOfficerContactNumber { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public Account Account { get; set; }
        public User AuditUser { get; set; }
        public BankType BankType { get; set; }
        public User MaintainedByUser { get; set; }
        public Office Office { get; set; }
        public ICollection<CustomerReceipt> CustomerReceipts { get; set; }
        public ICollection<MerchantFeeSetup> MerchantFeeSetups { get; set; }
        public ICollection<SupplierPayment> SupplierPayments { get; set; }
    }
}
