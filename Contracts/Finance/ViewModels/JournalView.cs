using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Finance.DTO
{
    public sealed class JournalView
    {
        public long TransactionMasterId { get; set; }
        public string TransactionCode { get; set; }
        public string Book { get; set; }
        public DateTime ValueDate { get; set; }
        public DateTime BookDate { get; set; }
        public string ReferenceNumber { get; set; }
        public string StatementReference { get; set; }
        public decimal Amount { get; set; }
        public string PostedBy { get; set; }
        public string Office { get; set; }
        public string Status { get; set; }
        public string VerifiedBy { get; set; }
        public DateTimeOffset VerifiedOn { get; set; }
        public string Reason { get; set; }
        public DateTimeOffset TransactionTs { get; set; }
    }
}
