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
    public class CompoundUnit
    {
        public int CompoundUnitId { get; set; }
        public int BaseUnitId { get; set; }
        public short Value { get; set; }
        public int CompareUnitId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Unit BaseUnit { get; set; }
        public Unit CompareUnit { get; set; }
    }
}
