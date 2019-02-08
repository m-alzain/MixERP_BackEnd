using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Core;
using Contracts.Auth;
//using ApplicationCore.Entities.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities.Auth
{
    public class GroupEntityAccessPolicy : IEntity, IAuditable
    {
        #region IEntity

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        #endregion

        public Guid EntityTypeId { get; set; }       
        public Guid RoleId { get; set; }
        public AccessType AccessType { get; set; }
        public bool AllowAccess { get; set; }
        public bool? Deleted { get; set; }
        public EntityType EntityType { get; set; }
        public Role Role { get; set; }

        #region IAuditable

        public Guid? CreatedByUserId { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }

        #endregion

        #region Commented (From the old system)

        //public int OfficeId { get; set; }
        //public Office Office { get; set; }
        //public int? AuditUserId { get; set; }
        //public User AuditUser { get; set; }
        //public DateTimeOffset? AuditTs { get; set; }

        #endregion
    }
}
