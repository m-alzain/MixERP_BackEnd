using ApplicationCore.Entities.Accounts;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Finance
{
    public class PaymentCard
    {        
        public int PaymentCardId { get; set; }
        public string PaymentCardCode { get; set; }
        public string PaymentCardName { get; set; }
        public int CardTypeId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public CardType CardType { get; set; }
        public ICollection<MerchantFeeSetup> MerchantFeeSetups { get; set; }
    }
}
