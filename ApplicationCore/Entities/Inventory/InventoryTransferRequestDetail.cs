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
    public class InventoryTransferRequestDetail
    {
        public long InventoryTransferRequestDetailId { get; set; }
        public long InventoryTransferRequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
        public int UnitId { get; set; }
        public int BaseUnitId { get; set; }
        public decimal BaseQuantity { get; set; }

        public Unit BaseUnit { get; set; }
        public InventoryTransferRequest InventoryTransferRequest { get; set; }
        public Item Item { get; set; }
        public Unit Unit { get; set; }
    }
}
