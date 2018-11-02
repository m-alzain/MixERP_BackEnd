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
    public class Return
    {
        public long ReturnId { get; set; }
        public long SalesId { get; set; }
        public long CheckoutId { get; set; }
        public long TransactionMasterId { get; set; }
        public long ReturnTransactionMasterId { get; set; }
        public int CounterId { get; set; }
        public int? CustomerId { get; set; }
        public int PriceTypeId { get; set; }
        public bool? IsCredit { get; set; }

        public Checkout Checkout { get; set; }
        public Counter Counter { get; set; }
        public Customer Customer { get; set; }
        public PriceType1 PriceType { get; set; }
        public TransactionMaster ReturnTransactionMaster { get; set; }
        public Sale Sales { get; set; }
        public TransactionMaster TransactionMaster { get; set; }
    }
}
