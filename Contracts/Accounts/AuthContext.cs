using Contracts.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Accounts
{
    public class AuthContext
    {
        public UserDto CurrentUser { get; set; }
        public TenantDto CurrentTenant { get; set; }
        public OfficeDto CurrentOffice { get; set; }
        public RoleDto CurrentRole { get; set; }
    }
}
