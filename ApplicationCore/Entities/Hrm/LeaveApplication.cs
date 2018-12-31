﻿using System;
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
    public class LeaveApplication
    {
        public long LeaveApplicationId { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public int EnteredBy { get; set; }
        public DateTime? AppliedOn { get; set; }
        public string Reason { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short VerificationStatusId { get; set; }
        public int? VerifiedByUserId { get; set; }
        public DateTime? VerifiedOn { get; set; }
        public string VerificationReason { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Employee Employee { get; set; }
        public User EnteredByNavigation { get; set; }
        public LeaveType LeaveType { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
        public User VerifiedByUser { get; set; }
    }
}