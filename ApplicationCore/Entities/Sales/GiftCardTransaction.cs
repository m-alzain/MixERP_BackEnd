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
    public class GiftCardTransaction
    {
        public long TransactionId { get; set; }
        public int GiftCardId { get; set; }
        public DateTime? ValueDate { get; set; }
        public DateTime? BookDate { get; set; }
        public long TransactionMasterId { get; set; }
        public string TransactionType { get; set; }
        public decimal? Amount { get; set; }

        public GiftCard GiftCard { get; set; }
        public TransactionMaster TransactionMaster { get; set; }
    }
}
