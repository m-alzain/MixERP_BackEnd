using System;
using System.Collections.Generic;
using ApplicationCore.Entities.Accounts;

namespace ApplicationCore.Entities.Finance
{
    public class CardType
    {
        public int CardTypeId { get; set; }
        public string CardTypeCode { get; set; }
        public string CardTypeName { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public ICollection<PaymentCard> PaymentCards { get; set; }
    }
}
