﻿using System;
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
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
