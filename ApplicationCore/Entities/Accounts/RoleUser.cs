using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Accounts
{
    public class RoleUser
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
