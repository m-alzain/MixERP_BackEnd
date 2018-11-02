using System;
using System.Collections.Generic;
using ApplicationCore.Entities.Config;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Auth;
using ApplicationCore.Entities.Calendar;
using ApplicationCore.Entities.Purchases;
using ApplicationCore.Entities.Sales;

namespace ApplicationCore.Entities.Inventory
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public ICollection<CheckoutDetail> CheckoutDetailBaseUnits { get; set; }
        public ICollection<CheckoutDetail> CheckoutDetailUnits { get; set; }
        public ICollection<CompoundUnit> CompoundUnitBaseUnits { get; set; }
        public ICollection<CompoundUnit> CompoundUnitCompareUnits { get; set; }
        public ICollection<CustomerwiseSellingPrice> CustomerwiseSellingPrices { get; set; }
        public ICollection<InventoryTransferDeliveryDetail> InventoryTransferDeliveryDetailBaseUnits { get; set; }
        public ICollection<InventoryTransferDeliveryDetail> InventoryTransferDeliveryDetailUnits { get; set; }
        public ICollection<InventoryTransferRequestDetail> InventoryTransferRequestDetailBaseUnits { get; set; }
        public ICollection<InventoryTransferRequestDetail> InventoryTransferRequestDetailUnits { get; set; }
        public ICollection<ItemCostPrice> ItemCostPrices { get; set; }
        public ICollection<Item> ItemReorderUnits { get; set; }
        public ICollection<ItemSellingPrice> ItemSellingPrices { get; set; }
        public ICollection<Item> ItemUnits { get; set; }
        public ICollection<OrderDetail1> OrderDetail1 { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<QuotationDetail1> QuotationDetail1 { get; set; }
        public ICollection<Purchases.QuotationDetail> QuotationDetails { get; set; }
        public ICollection<SerialNumber> SerialNumbers { get; set; }
        public ICollection<SupplierwiseCostPrice> SupplierwiseCostPrices { get; set; }
    }
}
