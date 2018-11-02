using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Inventory;
using ApplicationCore.Entities.Sales;

namespace ApplicationCore.Entities.Finance
{
    public class Account
    {
        public int AccountId { get; set; }
        public short AccountMasterId { get; set; }
        public string AccountNumber { get; set; }
        public string ExternalCode { get; set; }
        public string CurrencyCode { get; set; }
        public string AccountName { get; set; }
        public string Description { get; set; }
        public bool Confidential { get; set; }
        public bool? IsTransactionNode { get; set; }
        public bool SysType { get; set; }
        public int? ParentAccountId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public AccountMaster AccountMaster { get; set; }
        public User AuditUser { get; set; }
        public Currency CurrencyCodeNavigation { get; set; }
        public Account ParentAccount { get; set; }
        public Customer Customer { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<BankAccount> BankAccounts { get; set; }
        public ICollection<CustomerType> CustomerTypes { get; set; }
        public ICollection<GiftCard> GiftCards { get; set; }
        public ICollection<InventorySetup> InventorySetups { get; set; }
        public ICollection<Account> InverseParentAccount { get; set; }
        public ICollection<ItemGroup> ItemGroupCostOfGoodsSoldAccounts { get; set; }
        public ICollection<ItemGroup> ItemGroupInventoryAccounts { get; set; }
        public ICollection<ItemGroup> ItemGroupPurchaseAccounts { get; set; }
        public ICollection<ItemGroup> ItemGroupPurchaseDiscountAccounts { get; set; }
        public ICollection<ItemGroup> ItemGroupSalesAccounts { get; set; }
        public ICollection<ItemGroup> ItemGroupSalesDiscountAccounts { get; set; }
        public ICollection<ItemGroup> ItemGroupSalesReturnAccounts { get; set; }
        public ICollection<LateFee> LateFees { get; set; }
        public ICollection<MerchantFeeSetup> MerchantFeeSetups { get; set; }
        public ICollection<Shipper> Shippers { get; set; }
        public ICollection<Store> StoreDefaultAccountIdForChecksNavigations { get; set; }
        public ICollection<Store> StoreDefaultCashAccounts { get; set; }
        public ICollection<Store> StorePurchaseDiscountAccounts { get; set; }
        public ICollection<Store> StoreSalesDiscountAccounts { get; set; }
        public ICollection<Store> StoreShippingExpenseAccounts { get; set; }
        public ICollection<SupplierType> SupplierTypes { get; set; }
        public ICollection<TaxSetup> TaxSetupIncomeTaxAccounts { get; set; }
        public ICollection<TaxSetup> TaxSetupSalesTaxAccounts { get; set; }
        public ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
