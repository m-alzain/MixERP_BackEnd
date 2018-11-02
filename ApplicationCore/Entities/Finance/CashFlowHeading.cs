using System;
using System.Collections.Generic;
using ApplicationCore.Entities.Accounts;

namespace ApplicationCore.Entities.Finance
{
    public class CashFlowHeading
    {
        public int CashFlowHeadingId { get; set; }
        public string CashFlowHeadingCode { get; set; }
        public string CashFlowHeadingName { get; set; }
        public string CashFlowHeadingType { get; set; }
        public bool IsDebit { get; set; }
        public bool IsSales { get; set; }
        public bool IsPurchase { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public ICollection<CashFlowSetup> CashFlowSetups { get; set; }
    }
}
