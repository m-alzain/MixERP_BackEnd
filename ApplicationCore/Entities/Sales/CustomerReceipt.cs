using System;
using System.Collections.Generic;
using System.Text;
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
    public class CustomerReceipt
    {
        public long ReceiptId { get; set; }
        public long TransactionMasterId { get; set; }
        public int CustomerId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ErDebit { get; set; }
        public decimal ErCredit { get; set; }
        public int? CashRepositoryId { get; set; }
        public DateTime? PostedDate { get; set; }
        public decimal? Tender { get; set; }
        public decimal? Change { get; set; }
        public decimal? Amount { get; set; }
        public int? CollectedOnBankId { get; set; }
        public string CollectedBankInstrumentCode { get; set; }
        public string CollectedBankTransactionCode { get; set; }
        public string CheckNumber { get; set; }
        public DateTime? CheckDate { get; set; }
        public string CheckBankName { get; set; }
        public decimal? CheckAmount { get; set; }
        public bool? CheckCleared { get; set; }
        public DateTime? CheckClearDate { get; set; }
        public string CheckClearingMemo { get; set; }
        public long? CheckClearingTransactionMasterId { get; set; }
        public string GiftCardNumber { get; set; }

        public CashRepository CashRepository { get; set; }
        public TransactionMaster CheckClearingTransactionMaster { get; set; }
        public BankAccount CollectedOnBank { get; set; }
        public Currency CurrencyCodeNavigation { get; set; }
        public Customer Customer { get; set; }
        public TransactionMaster TransactionMaster { get; set; }
    }
}
