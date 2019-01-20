//using ApplicationCore.Entities.Auth;
//using System;
//using System.Collections.Generic;

//namespace ApplicationCore.Entities.Accounts
//{
//    public class Role
//    {
//        public int RoleId { get; set; }
//        public string RoleName { get; set; }
//        public bool IsAdministrator { get; set; }
//        public int? AuditUserId { get; set; }
//        public DateTimeOffset? AuditTs { get; set; }
//        public bool? Deleted { get; set; }

//        public User AuditUser { get; set; }
//        public ICollection<ConfigurationProfile> ConfigurationProfiles { get; set; }
//        public ICollection<GroupEntityAccessPolicy> GroupEntityAccessPolicies { get; set; }
//        public ICollection<GroupMenuAccessPolicy> GroupMenuAccessPolicies { get; set; }
//        public ICollection<User> Users { get; set; }
//    }
//}
