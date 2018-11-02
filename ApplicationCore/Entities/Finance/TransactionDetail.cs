using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Core;

namespace ApplicationCore.Entities.Finance
{
    public class TransactionDetail
    {
        public long TransactionDetailId { get; set; }
        public long TransactionMasterId { get; set; }
        public DateTime ValueDate { get; set; }
        public DateTime BookDate { get; set; }
        public string TranType { get; set; }
        public int AccountId { get; set; }
        public string StatementReference { get; set; }
        public string ReconciliationMemo { get; set; }
        public int? CashRepositoryId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal AmountInCurrency { get; set; }
        public string LocalCurrencyCode { get; set; }
        public decimal Er { get; set; }
        public decimal AmountInLocalCurrency { get; set; }
        public int OfficeId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }

        public Account Account { get; set; }
        public User AuditUser { get; set; }
        public CashRepository CashRepository { get; set; }
        public Currency CurrencyCodeNavigation { get; set; }
        public Currency LocalCurrencyCodeNavigation { get; set; }
        public Office Office { get; set; }
        public TransactionMaster TransactionMaster { get; set; }
    }
}
