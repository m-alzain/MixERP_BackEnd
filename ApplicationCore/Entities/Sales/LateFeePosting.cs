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
    public class LateFeePosting
    {
        public long TransactionMasterId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ValueDate { get; set; }
        public long LateFeeTranId { get; set; }
        public decimal? Amount { get; set; }

        public Customer Customer { get; set; }
        public TransactionMaster LateFeeTran { get; set; }
        public TransactionMaster TransactionMaster { get; set; }
    }
}
