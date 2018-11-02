using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Purchases
{
    public class SupplierPayment
    {
        public long PaymentId { get; set; }
        public long TransactionMasterId { get; set; }
        public int SupplierId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ErDebit { get; set; }
        public decimal ErCredit { get; set; }
        public int? CashRepositoryId { get; set; }
        public DateTime? PostedDate { get; set; }
        public decimal? Tender { get; set; }
        public decimal? Change { get; set; }
        public decimal? Amount { get; set; }
        public int? BankId { get; set; }
        public string BankInstrumentCode { get; set; }
        public string BankTransactionCode { get; set; }
        public string CheckNumber { get; set; }
        public DateTime? CheckDate { get; set; }
        public string CheckBankName { get; set; }
        public decimal? CheckAmount { get; set; }

        public BankAccount Bank { get; set; }
        public CashRepository CashRepository { get; set; }
        public Currency CurrencyCodeNavigation { get; set; }
        public Supplier Supplier { get; set; }
        public TransactionMaster TransactionMaster { get; set; }
    }
}
