using ApplicationCore.Entities.Hrm;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Core
{
    public class Country
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
