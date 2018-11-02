using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Finance;

namespace ApplicationCore.Entities.Inventory
{
    public class ItemGroup
    {
        public int ItemGroupId { get; set; }
        public string ItemGroupCode { get; set; }
        public string ItemGroupName { get; set; }
        public bool ExcludeFromPurchase { get; set; }
        public bool ExcludeFromSales { get; set; }
        public int SalesAccountId { get; set; }
        public int SalesDiscountAccountId { get; set; }
        public int SalesReturnAccountId { get; set; }
        public int PurchaseAccountId { get; set; }
        public int PurchaseDiscountAccountId { get; set; }
        public int InventoryAccountId { get; set; }
        public int CostOfGoodsSoldAccountId { get; set; }
        public int? ParentItemGroupId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Account CostOfGoodsSoldAccount { get; set; }
        public Account InventoryAccount { get; set; }
        public ItemGroup ParentItemGroup { get; set; }
        public Account PurchaseAccount { get; set; }
        public Account PurchaseDiscountAccount { get; set; }
        public Account SalesAccount { get; set; }
        public Account SalesDiscountAccount { get; set; }
        public Account SalesReturnAccount { get; set; }
        public ICollection<ItemGroup> InverseParentItemGroup { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
