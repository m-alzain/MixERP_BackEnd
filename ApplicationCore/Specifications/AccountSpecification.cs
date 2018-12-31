using ApplicationCore.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Specifications
{
    public class AccountSpecification : BaseSpecification<Account>
    {
        public AccountSpecification(
            string tenant = null, 
            string accountNumber = null, 
            short? accountMasterId = null, 
            bool? isTransactionNode = null,
            bool? confidential = null)
            : base(a =>            
            (string.IsNullOrEmpty(tenant) /*|| a.Tenant == tenant*/)
            && (string.IsNullOrEmpty(accountNumber) || a.AccountNumber == accountNumber) 
            && (!accountMasterId.HasValue || a.AccountMasterId == accountMasterId.Value)
            && (!isTransactionNode.HasValue || a.IsTransactionNode == isTransactionNode)
            && (!confidential.HasValue || a.Confidential == confidential.Value)
            && (!a.Deleted.HasValue || a.Deleted.Value == false)
            )
        {
        }
    }
}
