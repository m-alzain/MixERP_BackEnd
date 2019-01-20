//using System;
//using System.Collections.Generic;
//using System.Text;
//using ApplicationCore.Entities.Finance;
//using ApplicationCore.Entities.Inventory;
//using ApplicationCore.Entities.Purchases;
//using ApplicationCore.Entities.Sales;

//namespace ApplicationCore.Entities.Core
//{
//    public class Currency
//    {
//        public int CurrencyId { get; set; }
//        public string CurrencyCode { get; set; }
//        public string CurrencySymbol { get; set; }
//        public string CurrencyName { get; set; }
//        public string HundredthName { get; set; }
//        public int? AuditUserId { get; set; }
//        public DateTimeOffset? AuditTs { get; set; }
//        public bool? Deleted { get; set; }

//        public ICollection<Account> Accounts { get; set; }
//        public ICollection<CustomerReceipt> CustomerReceipts { get; set; }
//        public ICollection<Customer> Customers { get; set; }
//        public ICollection<ExchangeRateDetail> ExchangeRateDetailForeignCurrencyCodeNavigations { get; set; }
//        public ICollection<ExchangeRateDetail> ExchangeRateDetailLocalCurrencyCodeNavigations { get; set; }
//        public ICollection<SupplierPayment> SupplierPayments { get; set; }
//        public ICollection<Supplier> Suppliers { get; set; }
//        public ICollection<TransactionDetail> TransactionDetailCurrencyCodeNavigations { get; set; }
//        public ICollection<TransactionDetail> TransactionDetailLocalCurrencyCodeNavigations { get; set; }
//    }
//}
