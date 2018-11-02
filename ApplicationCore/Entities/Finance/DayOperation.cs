using System;
using System.Collections.Generic;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Core;

namespace ApplicationCore.Entities.Finance
{
    public class DayOperation
    {
        public long DayId { get; set; }
        public int OfficeId { get; set; }
        public DateTime ValueDate { get; set; }
        public DateTimeOffset StartedOn { get; set; }
        public int StartedBy { get; set; }
        public DateTimeOffset? CompletedOn { get; set; }
        public int? CompletedBy { get; set; }
        public bool Completed { get; set; }

        public User CompletedByNavigation { get; set; }
        public Office Office { get; set; }
        public User StartedByNavigation { get; set; }
        public ICollection<DayOperationRoutine> DayOperationRoutines { get; set; }
    }
}
