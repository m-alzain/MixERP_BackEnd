using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities.Accounts;

namespace ApplicationCore.Entities.Finance
{
    public class AccountMaster
    {
        public short AccountMasterId { get; set; }
        public string AccountMasterCode { get; set; }
        public string AccountMasterName { get; set; }
        public bool NormallyDebit { get; set; }
        public short? ParentAccountMasterId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public AccountMaster ParentAccountMaster { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public ICollection<CashFlowSetup> CashFlowSetups { get; set; }
        public ICollection<AccountMaster> InverseParentAccountMaster { get; set; }
    }
}
