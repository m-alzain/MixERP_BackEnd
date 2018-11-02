using ApplicationCore.Entities.Core;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Accounts
{
    public class ConfigurationProfile
    {
        public int ConfigurationProfileId { get; set; }
        public string ProfileName { get; set; }
        public bool? IsActive { get; set; }
        public bool? AllowRegistration { get; set; }
        public int RegistrationOfficeId { get; set; }
        public int RegistrationRoleId { get; set; }
        public bool? AllowFacebookRegistration { get; set; }
        public bool? AllowGoogleRegistration { get; set; }
        public string GoogleSigninClientId { get; set; }
        public string GoogleSigninScope { get; set; }
        public string FacebookAppId { get; set; }
        public string FacebookScope { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Office RegistrationOffice { get; set; }
        public Role RegistrationRole { get; set; }
    }
}
