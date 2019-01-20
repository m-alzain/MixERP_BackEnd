//using ApplicationCore.Entities.Auth;
//using System;
//using System.Collections.Generic;

//namespace ApplicationCore.Entities.Core
//{
//    public class Menu
//    {
//        public int MenuId { get; set; }
//        public int? Sort { get; set; }
//        public string I18nKey { get; set; }
//        public string AppName { get; set; }
//        public string MenuName { get; set; }
//        public string Url { get; set; }
//        public string Icon { get; set; }
//        public int? ParentMenuId { get; set; }
//        public int? AuditUserId { get; set; }
//        public DateTimeOffset? AuditTs { get; set; }
//        public bool? Deleted { get; set; }

//        public App AppNameNavigation { get; set; }
//        public Menu ParentMenu { get; set; }
//        public ICollection<GroupMenuAccessPolicy> GroupMenuAccessPolicies { get; set; }
//        public ICollection<Menu> InverseParentMenu { get; set; }
//        public ICollection<MenuAccessPolicy> MenuAccessPolicies { get; set; }
//        public ICollection<Notification> Notifications { get; set; }
//    }
//}
