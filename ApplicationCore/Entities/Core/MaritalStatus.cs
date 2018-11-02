using ApplicationCore.Entities.Hrm;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Core
{
    public class MaritalStatus
    {
        public int MaritalStatusId { get; set; }
        public string MaritalStatusCode { get; set; }
        public string MaritalStatusName { get; set; }
        public bool IsLegallyRecognizedMarriage { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
