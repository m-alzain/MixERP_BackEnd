using ApplicationCore.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Accounts
{
    public class OfficeUser
    {
        public Guid OfficeId { get; set; }
        public Guid UserId { get; set; }

        public Office Office { get; set; }
        public User User { get; set; }

    }
}
