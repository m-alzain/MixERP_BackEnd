using System;
using System.Collections.Generic;
using ApplicationCore.Entities.Config;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Auth;
using ApplicationCore.Entities.Calendar;
using ApplicationCore.Entities.Purchases;

namespace ApplicationCore.Entities.Inventory
{
    public class SerialNumber
    {
        public long SerialNumberId { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public int StoreId { get; set; }
        public string TransactionType { get; set; }
        public long CheckoutId { get; set; }
        public string BatchNumber { get; set; }
        public string SerialNumber1 { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public long? SalesTransactionId { get; set; }
        public bool Deleted { get; set; }

        public Checkout Checkout { get; set; }
        public Item Item { get; set; }
        public TransactionMaster SalesTransaction { get; set; }
        public Store Store { get; set; }
        public Unit Unit { get; set; }
    }
}
