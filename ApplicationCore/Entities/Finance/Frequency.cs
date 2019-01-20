//using System;
//using System.Collections.Generic;
//using ApplicationCore.Entities.Accounts;
//using ApplicationCore.Entities.Sales;

//namespace ApplicationCore.Entities.Finance
//{
//    public class Frequency
//    {
//        public int FrequencyId { get; set; }
//        public string FrequencyCode { get; set; }
//        public string FrequencyName { get; set; }
//        public int? AuditUserId { get; set; }
//        public DateTimeOffset? AuditTs { get; set; }
//        public bool? Deleted { get; set; }

//        public User AuditUser { get; set; }
//        public ICollection<FrequencySetup> FrequencySetups { get; set; }
//        public ICollection<PaymentTerm> PaymentTermDueFrequencies { get; set; }
//        public ICollection<PaymentTerm> PaymentTermLateFeePostingFrequencies { get; set; }
//    }
//}
