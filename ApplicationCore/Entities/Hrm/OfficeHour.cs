using System;
using System.Collections.Generic;
using ApplicationCore.Entities.Config;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Auth;
using ApplicationCore.Entities.Calendar;
using ApplicationCore.Entities.Inventory;
using ApplicationCore.Entities.Purchases;

namespace ApplicationCore.Entities.Hrm
{
    public class OfficeHour
    {
        public int OfficeHourId { get; set; }
        public int OfficeId { get; set; }
        public int ShiftId { get; set; }
        public int WeekDayId { get; set; }
        public TimeSpan BeginsFrom { get; set; }
        public TimeSpan EndsOn { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Office Office { get; set; }
        public Shift Shift { get; set; }
        public WeekDay1 WeekDay { get; set; }
    }
}
