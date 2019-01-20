//using System;
//using System.Collections.Generic;

//namespace ApplicationCore.Entities.Core
//{
//    public class App
//    {
//        public int AppId { get; set; }
//        public string AppName { get; set; }
//        public string I18nKey { get; set; }
//        public string Name { get; set; }
//        public string VersionNumber { get; set; }
//        public string Publisher { get; set; }
//        public DateTime? PublishedOn { get; set; }
//        public string Icon { get; set; }
//        public string LandingUrl { get; set; }
//        public int? AuditUserId { get; set; }
//        public DateTimeOffset? AuditTs { get; set; }
//        public bool? Deleted { get; set; }

//        public ICollection<AppDependency> AppDependencyAppNameNavigations { get; set; }
//        public ICollection<AppDependency> AppDependencyDependsOnNavigations { get; set; }
//        public ICollection<Menu> Menus { get; set; }
//        public ICollection<Notification> Notifications { get; set; }
//    }
//}
