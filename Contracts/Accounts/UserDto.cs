using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Accounts
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }       
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool? Status { get; set; }
        public DateTimeOffset? LastSeenOn { get; set; }
        public string LastIp { get; set; }
        public string LastBrowser { get; set; }
        public bool Deleted { get; set; }

        public IList<OfficeDto> Offices { get; set; }
        public IList<RoleDto> Roles { get; set; }


        #region Audit

        public Guid? CreatedByUserId { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }        

        #endregion
    }
}
