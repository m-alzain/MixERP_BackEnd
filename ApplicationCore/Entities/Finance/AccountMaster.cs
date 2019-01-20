using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities.Accounts;

namespace ApplicationCore.Entities.Finance
{
    public class AccountMaster
    {
        public Guid AccountMasterId { get; set; }
        public string AccountMasterCode { get; set; }
        public string AccountMasterName { get; set; }
        public bool NormallyDebit { get; set; }
        public Guid? ParentAccountMasterId { get; set; }        
        public bool? Deleted { get; set; }

        public Guid CreatedByUserId { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public Guid UpdatedByUserId { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }

        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }

        public AccountMaster ParentAccountMaster { get; set; }
        //public ICollection<Account> Accounts { get; set; }
        //public ICollection<CashFlowSetup> CashFlowSetups { get; set; }
        //public ICollection<AccountMaster> InverseParentAccountMaster { get; set; }
    }
}
