using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.QueryModels
{
    public class EntryQuery
    {      
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Code { get; set; }
        public string ReferenceNumber { get; set; }
        public int? StatusId { get; set; }
        public int? OfficeId { get; set; }
    }
}
