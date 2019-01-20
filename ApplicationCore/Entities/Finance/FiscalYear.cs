//using System;
//using System.Collections.Generic;
//using ApplicationCore.Entities.Accounts;
//using ApplicationCore.Entities.Core;
//using ApplicationCore.Entities.Sales;

//namespace ApplicationCore.Entities.Finance
//{
//    public class FiscalYear
//    {
//        public int FiscalYearId { get; set; }
//        public string FiscalYearCode { get; set; }
//        public string FiscalYearName { get; set; }
//        public DateTime StartsFrom { get; set; }
//        public DateTime EndsOn { get; set; }
//        public bool? EodRequired { get; set; }
//        public int OfficeId { get; set; }
//        public int? AuditUserId { get; set; }
//        public DateTimeOffset? AuditTs { get; set; }
//        public bool? Deleted { get; set; }

//        public User AuditUser { get; set; }
//        public Office Office { get; set; }
//        public ICollection<FrequencySetup> FrequencySetups { get; set; }
//        public ICollection<Sale> Sales { get; set; }
//    }
//}
