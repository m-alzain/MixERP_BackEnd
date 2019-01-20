//using System;
//using System.Collections.Generic;

//namespace ApplicationCore.Entities.Core
//{
//    public class Notification
//    {
//        public Guid NotificationId { get; set; }
//        public DateTimeOffset EventTimestamp { get; set; }
//        public string Tenant { get; set; }
//        public int? OfficeId { get; set; }
//        public string AssociatedApp { get; set; }
//        public int? AssociatedMenuId { get; set; }
//        public int? ToUserId { get; set; }
//        public int? ToRoleId { get; set; }
//        public long? ToLoginId { get; set; }
//        public string Url { get; set; }
//        public string FormattedText { get; set; }
//        public string Icon { get; set; }

//        public App AssociatedAppNavigation { get; set; }
//        public Menu AssociatedMenu { get; set; }
//        public Office Office { get; set; }
//        public ICollection<NotificationStatus> NotificationStatuses { get; set; }
//    }
//}
