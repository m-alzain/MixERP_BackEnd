using Contracts.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Accounts
{
    public class RoleDto
    {
        public Guid OfficeId { get; set; }
  
        public Guid Id { get; set; }

        public string RoleName { get; set; }
        public bool IsAdministrator { get; set; }
        public bool? Deleted { get; set; }

        public IList<GroupEntityAccessPolicyDto> GroupEntityAccessPolicies { get; set; }

        #region IAuditable

        public Guid? CreatedByUserId { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }

        #endregion

    }
}
