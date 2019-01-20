//using System;
//using System.Collections.Generic;
//using ApplicationCore.Entities.Accounts;
//using ApplicationCore.Entities.Core;

//namespace ApplicationCore.Entities.Finance
//{
//    public class FrequencySetup
//    {
//        public int FrequencySetupId { get; set; }
//        public string FiscalYearCode { get; set; }
//        public string FrequencySetupCode { get; set; }
//        public DateTime ValueDate { get; set; }
//        public int FrequencyId { get; set; }
//        public int OfficeId { get; set; }
//        public int? AuditUserId { get; set; }
//        public DateTimeOffset? AuditTs { get; set; }
//        public bool? Deleted { get; set; }

//        public User AuditUser { get; set; }
//        public FiscalYear FiscalYearCodeNavigation { get; set; }
//        public Frequency Frequency { get; set; }
//        public Office Office { get; set; }
//    }
//}
