using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Core;

namespace ApplicationCore.Entities.Finance
{
    public class TaxSetup
    {
        public int TaxSetupId { get; set; }
        public int OfficeId { get; set; }
        public decimal IncomeTaxRate { get; set; }
        public int IncomeTaxAccountId { get; set; }
        public decimal SalesTaxRate { get; set; }
        public int SalesTaxAccountId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Account IncomeTaxAccount { get; set; }
        public Office Office { get; set; }
        public Account SalesTaxAccount { get; set; }
    }
}
