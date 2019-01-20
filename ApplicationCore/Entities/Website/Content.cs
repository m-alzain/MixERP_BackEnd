//using ApplicationCore.Entities.Accounts;
//using System;
//using System.Collections.Generic;

//namespace ApplicationCore.Entities.Website
//{
//    public class Content
//    {
//        public int ContentId { get; set; }
//        public int CategoryId { get; set; }
//        public string Title { get; set; }
//        public string Alias { get; set; }
//        public int? AuthorId { get; set; }
//        public DateTimeOffset PublishOn { get; set; }
//        public DateTimeOffset CreatedOn { get; set; }
//        public int? LastEditorId { get; set; }
//        public DateTimeOffset? LastEditedOn { get; set; }
//        public string Markdown { get; set; }
//        public string Contents { get; set; }
//        public string Tags { get; set; }
//        public long? Hits { get; set; }
//        public bool? IsDraft { get; set; }
//        public string SeoDescription { get; set; }
//        public bool IsHomepage { get; set; }
//        public int? AuditUserId { get; set; }
//        public DateTimeOffset? AuditTs { get; set; }
//        public bool? Deleted { get; set; }

//        public User AuditUser { get; set; }
//        public User Author { get; set; }
//        public Category Category { get; set; }
//        public User LastEditor { get; set; }
//        public ICollection<MenuItem> MenuItems { get; set; }
//    }
//}
