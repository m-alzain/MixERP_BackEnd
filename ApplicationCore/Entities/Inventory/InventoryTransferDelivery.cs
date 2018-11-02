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
    public class InventoryTransferDelivery
    {
        public long InventoryTransferDeliveryId { get; set; }
        public long InventoryTransferRequestId { get; set; }
        public int OfficeId { get; set; }
        public int UserId { get; set; }
        public int DestinationStoreId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTimeOffset TransactionTimestamp { get; set; }
        public string ReferenceNumber { get; set; }
        public string StatementReference { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Store DestinationStore { get; set; }
        public InventoryTransferRequest InventoryTransferRequest { get; set; }
        public Office Office { get; set; }
        public User User { get; set; }
        public ICollection<InventoryTransferDeliveryDetail> InventoryTransferDeliveryDetails { get; set; }
    }
}
