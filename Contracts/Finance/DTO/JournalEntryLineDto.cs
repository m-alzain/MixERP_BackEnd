using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Finance.DTO
{
    // V2 code
    public class JournalEntryLineDto
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
        
    }
}
