using Contracts.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Auth
{
    public class GroupEntityAccessPolicyDto
    {
        public Guid Id { get; set; }

        public Guid EntityTypeId { get; set; }
        public Guid RoleId { get; set; }
        public AccessType AccessType { get; set; }
        public bool AllowAccess { get; set; }
        public bool? Deleted { get; set; }
        public EntityTypeDto EntityType { get; set; }
        public string RoleName { get; set; }

        #region IAuditable

        public Guid? CreatedByUserId { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }

        #endregion
    }
}
