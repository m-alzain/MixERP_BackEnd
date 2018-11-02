using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Sales;

using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities.Purchases;

namespace ApplicationCore.Entities.Inventory
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Barcode { get; set; }
        public int ItemGroupId { get; set; }
        public int ItemTypeId { get; set; }
        public int? BrandId { get; set; }
        public int? PreferredSupplierId { get; set; }
        public int? LeadTimeInDays { get; set; }
        public int UnitId { get; set; }
        public bool HotItem { get; set; }
        public bool? IsTaxableItem { get; set; }
        public decimal? CostPrice { get; set; }
        public bool CostPriceIncludesTax { get; set; }
        public decimal? SellingPrice { get; set; }
        public bool SellingPriceIncludesTax { get; set; }
        public int ReorderLevel { get; set; }
        public decimal ReorderQuantity { get; set; }
        public int ReorderUnitId { get; set; }
        public bool? MaintainInventory { get; set; }
        public byte[] Photo { get; set; }
        public bool? AllowSales { get; set; }
        public bool? AllowPurchase { get; set; }
        public int? IsVariantOf { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Brand Brand { get; set; }
        public Item IsVariantOfNavigation { get; set; }
        public ItemGroup ItemGroup { get; set; }
        public ItemType ItemType { get; set; }
        public Supplier PreferredSupplier { get; set; }
        public Unit ReorderUnit { get; set; }
        public Unit Unit { get; set; }
        public ICollection<CheckoutDetail> CheckoutDetails { get; set; }
        public ICollection<CustomerwiseSellingPrice> CustomerwiseSellingPrices { get; set; }
        public ICollection<InventoryTransferDeliveryDetail> InventoryTransferDeliveryDetails { get; set; }
        public ICollection<InventoryTransferRequestDetail> InventoryTransferRequestDetails { get; set; }
        public ICollection<Item> InverseIsVariantOfNavigation { get; set; }
        public ICollection<ItemCostPrice> ItemCostPrices { get; set; }
        public ICollection<ItemSellingPrice> ItemSellingPrices { get; set; }
        public ICollection<ItemVariant> ItemVariants { get; set; }
        public ICollection<OrderDetail1> OrderDetail1 { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<QuotationDetail1> QuotationDetail1 { get; set; }
        public ICollection<Purchases.QuotationDetail> QuotationDetails { get; set; }
        public ICollection<SerialNumber> SerialNumbers { get; set; }
        public ICollection<SupplierwiseCostPrice> SupplierwiseCostPrices { get; set; }
    }
}
