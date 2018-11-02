using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Sales;

namespace ApplicationCore.Entities.Inventory
{
    public class SupplierType
    {
        public int SupplierTypeId { get; set; }
        public string SupplierTypeCode { get; set; }
        public string SupplierTypeName { get; set; }
        public int AccountId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public Account Account { get; set; }
        public User AuditUser { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
    }
}
