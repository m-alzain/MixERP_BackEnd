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
    public class LateFee
    {
        public int LateFeeId { get; set; }
        public string LateFeeCode { get; set; }
        public string LateFeeName { get; set; }
        public bool IsFlatAmount { get; set; }
        public decimal Rate { get; set; }
        public int AccountId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public Account Account { get; set; }
        public User AuditUser { get; set; }
        public ICollection<PaymentTerm> PaymentTerms { get; set; }
    }
}
