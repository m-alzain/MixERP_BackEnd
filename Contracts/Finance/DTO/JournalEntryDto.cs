using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Finance.DTO
{
    // V2 code
    public class JournalEntryDto
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
        
        public ICollection<JournalEntryLineDto> JournalEntryLines { get; set; }        
    }
}
