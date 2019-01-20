//using System;
//using System.Collections.Generic;
//using System.Text;
//using ApplicationCore.Entities.Accounts;

//namespace ApplicationCore.Entities.Finance
//{
//    public class MerchantFeeSetup
//    {
//        public int MerchantFeeSetupId { get; set; }
//        public int MerchantAccountId { get; set; }
//        public int PaymentCardId { get; set; }
//        public decimal Rate { get; set; }
//        public bool CustomerPaysFee { get; set; }
//        public int AccountId { get; set; }
//        public string StatementReference { get; set; }
//        public int? AuditUserId { get; set; }
//        public DateTimeOffset? AuditTs { get; set; }
//        public bool? Deleted { get; set; }

//        public Account Account { get; set; }
//        public User AuditUser { get; set; }
//        public BankAccount MerchantAccount { get; set; }
//        public PaymentCard PaymentCard { get; set; }
//    }
//}
