//using System;
//using System.Collections.Generic;
//using ApplicationCore.Entities.Accounts;
//using ApplicationCore.Entities.Core;
//using ApplicationCore.Entities.Inventory;
//using ApplicationCore.Entities.Purchases;
//using ApplicationCore.Entities.Sales;

//namespace ApplicationCore.Entities.Finance
//{
//    public class CashRepository
//    {
//        public int CashRepositoryId { get; set; }
//        public int OfficeId { get; set; }
//        public string CashRepositoryCode { get; set; }
//        public string CashRepositoryName { get; set; }
//        public int? ParentCashRepositoryId { get; set; }
//        public string Description { get; set; }
//        public int? AuditUserId { get; set; }
//        public DateTimeOffset? AuditTs { get; set; }
//        public bool? Deleted { get; set; }

//        public User AuditUser { get; set; }
//        public Office Office { get; set; }
//        public CashRepository ParentCashRepository { get; set; }
//        public ICollection<CustomerReceipt> CustomerReceipts { get; set; }
//        public ICollection<CashRepository> InverseParentCashRepository { get; set; }
//        public ICollection<Sale> Sales { get; set; }
//        public ICollection<Store> Stores { get; set; }
//        public ICollection<SupplierPayment> SupplierPayments { get; set; }
//        public ICollection<TransactionDetail> TransactionDetails { get; set; }
//    }
//}
