using ApplicationCore.Entities.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities.Accounts
{
    public class Role : IEntity, IOffice, IAuditable
    {
        #region IOffice

        public Guid OfficeId { get; set; }
        public Office Office { get; set; }

        #endregion

        #region IEntity

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        #endregion

        public string RoleName { get; set; }
        public bool IsAdministrator { get; set; }        
        public bool? Deleted { get; set; }
     
        public ICollection<GroupEntityAccessPolicy> GroupEntityAccessPolicies { get; set; }
        public ICollection<RoleUser> RoleUsers { get; set; }

        #region IAuditable

        public Guid? CreatedByUserId { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }

        #endregion

        #region Commented (From the old system)

        //public ICollection<ConfigurationProfile> ConfigurationProfiles { get; set; }     
        //public ICollection<GroupMenuAccessPolicy> GroupMenuAccessPolicies { get; set; }

        #endregion
    }
}
