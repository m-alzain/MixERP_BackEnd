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
    public class InventoryTransferRequest
    {
        public long InventoryTransferRequestId { get; set; }
        public int OfficeId { get; set; }
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTimeOffset TransactionTimestamp { get; set; }
        public string ReferenceNumber { get; set; }
        public string StatementReference { get; set; }
        public bool Authorized { get; set; }
        public int? AuthorizedByUserId { get; set; }
        public DateTimeOffset? AuthorizedOn { get; set; }
        public string AuthorizationReason { get; set; }
        public bool Rejected { get; set; }
        public int? RejectedByUserId { get; set; }
        public DateTimeOffset? RejectedOn { get; set; }
        public string RejectionReason { get; set; }
        public bool Received { get; set; }
        public int? ReceivedByUserId { get; set; }
        public DateTimeOffset? ReceivedOn { get; set; }
        public string ReceiptMemo { get; set; }
        public bool Delivered { get; set; }
        public int? DeliveredByUserId { get; set; }
        public DateTimeOffset? DeliveredOn { get; set; }
        public string DeliveryMemo { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public User AuthorizedByUser { get; set; }
        public User DeliveredByUser { get; set; }
        public Office Office { get; set; }
        public User ReceivedByUser { get; set; }
        public User RejectedByUser { get; set; }
        public Store Store { get; set; }
        public User User { get; set; }
        public ICollection<InventoryTransferDelivery> InventoryTransferDeliveries { get; set; }
        public ICollection<InventoryTransferRequestDetail> InventoryTransferRequestDetails { get; set; }
    }
}
