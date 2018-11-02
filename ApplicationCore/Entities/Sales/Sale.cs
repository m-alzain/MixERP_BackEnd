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
    public class Sale
    {
        public long SalesId { get; set; }
        public long InvoiceNumber { get; set; }
        public string FiscalYearCode { get; set; }
        public int? CashRepositoryId { get; set; }
        public int PriceTypeId { get; set; }
        public long? SalesOrderId { get; set; }
        public long? SalesQuotationId { get; set; }
        public long? ReceiptTransactionMasterId { get; set; }
        public long TransactionMasterId { get; set; }
        public long CheckoutId { get; set; }
        public int CounterId { get; set; }
        public int? CustomerId { get; set; }
        public int? SalespersonId { get; set; }
        public decimal TotalAmount { get; set; }
        public int? CouponId { get; set; }
        public bool? IsFlatDiscount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TotalDiscountAmount { get; set; }
        public bool IsCredit { get; set; }
        public bool? CreditSettled { get; set; }
        public int? PaymentTermId { get; set; }
        public decimal Tender { get; set; }
        public decimal Change { get; set; }
        public int? GiftCardId { get; set; }
        public string CheckNumber { get; set; }
        public DateTime? CheckDate { get; set; }
        public string CheckBankName { get; set; }
        public decimal? CheckAmount { get; set; }
        public decimal RewardPoints { get; set; }

        public CashRepository CashRepository { get; set; }
        public Checkout Checkout { get; set; }
        public Counter Counter { get; set; }
        public Coupon Coupon { get; set; }
        public Customer Customer { get; set; }
        public FiscalYear FiscalYearCodeNavigation { get; set; }
        public GiftCard GiftCard { get; set; }
        public PaymentTerm PaymentTerm { get; set; }
        public PriceType1 PriceType { get; set; }
        public TransactionMaster ReceiptTransactionMaster { get; set; }
        public Order1 SalesOrder { get; set; }
        public Quotation1 SalesQuotation { get; set; }
        public User Salesperson { get; set; }
        public TransactionMaster TransactionMaster { get; set; }
        public ICollection<Return> Returns { get; set; }
    }
}
