//using ApplicationCore.Entities.Accounts;
//using ApplicationCore.Entities.Config;
//using System;
//using System.Collections.Generic;

//namespace ApplicationCore.Entities.Config
//{
//    public class CustomFieldSetup
//    {
//        public int CustomFieldSetupId { get; set; }
//        public string FormName { get; set; }
//        public string BeforeField { get; set; }
//        public int FieldOrder { get; set; }
//        public string AfterField { get; set; }
//        public string FieldName { get; set; }
//        public string FieldLabel { get; set; }
//        public string DataType { get; set; }
//        public string Description { get; set; }
//        public int? AuditUserId { get; set; }
//        public DateTimeOffset? AuditTs { get; set; }
//        public bool? Deleted { get; set; }

//        public User AuditUser { get; set; }
//        public CustomFieldDataType DataTypeNavigation { get; set; }
//        public CustomFieldForm FormNameNavigation { get; set; }
//        public ICollection<CustomField> CustomFields { get; set; }
//    }
//}
