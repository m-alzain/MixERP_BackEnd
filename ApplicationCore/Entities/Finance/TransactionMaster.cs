using System;
using System.Collections.Generic;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Inventory;
using ApplicationCore.Entities.Purchases;
using ApplicationCore.Entities.Sales;

namespace ApplicationCore.Entities.Finance
{
    public class TransactionMaster
    {
        public long TransactionMasterId { get; set; }
        public int TransactionCounter { get; set; }
        public string TransactionCode { get; set; }
        public string Book { get; set; }
        public DateTime ValueDate { get; set; }
        public DateTime BookDate { get; set; }
        public DateTimeOffset TransactionTs { get; set; }
        public long LoginId { get; set; }
        public int UserId { get; set; }
        public int OfficeId { get; set; }
        public int? CostCenterId { get; set; }
        public string ReferenceNumber { get; set; }
        public string StatementReference { get; set; }
        public DateTimeOffset? LastVerifiedOn { get; set; }
        public int? VerifiedByUserId { get; set; }
        public short VerificationStatusId { get; set; }
        public string VerificationReason { get; set; }
        public long? CascadingTranId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public TransactionMaster CascadingTran { get; set; }
        public CostCenter CostCenter { get; set; }
        public Login Login { get; set; }
        public Office Office { get; set; }
        public User User { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
        public User VerifiedByUser { get; set; }
        public LateFeePosting LateFeePostingTransactionMaster { get; set; }
        public ICollection<Checkout> Checkouts { get; set; }
        public ICollection<CustomerReceipt> CustomerReceiptCheckClearingTransactionMasters { get; set; }
        public ICollection<CustomerReceipt> CustomerReceiptTransactionMasters { get; set; }
        public ICollection<GiftCardTransaction> GiftCardTransactions { get; set; }
        public ICollection<TransactionMaster> InverseCascadingTran { get; set; }
        public ICollection<LateFeePosting> LateFeePostingLateFeeTrans { get; set; }
        public ICollection<Return> ReturnReturnTransactionMasters { get; set; }
        public ICollection<Return> ReturnTransactionMasters { get; set; }
        public ICollection<Sale> SaleReceiptTransactionMasters { get; set; }
        public ICollection<Sale> SaleTransactionMasters { get; set; }
        public ICollection<SerialNumber> SerialNumbers { get; set; }
        public ICollection<SupplierPayment> SupplierPayments { get; set; }
        public ICollection<TransactionDetail> TransactionDetails { get; set; }
        public ICollection<TransactionDocument> TransactionDocuments { get; set; }
    }
}
