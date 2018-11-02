using System;
using System.Collections.Generic;
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
    public class PaymentTerm
    {
        public int PaymentTermId { get; set; }
        public string PaymentTermCode { get; set; }
        public string PaymentTermName { get; set; }
        public bool DueOnDate { get; set; }
        public int DueDays { get; set; }
        public int? DueFrequencyId { get; set; }
        public int GracePeriod { get; set; }
        public int? LateFeeId { get; set; }
        public int? LateFeePostingFrequencyId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Frequency DueFrequency { get; set; }
        public LateFee LateFee { get; set; }
        public Frequency LateFeePostingFrequency { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
