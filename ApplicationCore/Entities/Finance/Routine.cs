using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Finance
{
    public class Routine
    {
        public int RoutineId { get; set; }
        public int Order { get; set; }
        public string RoutineCode { get; set; }
        public string RoutineName { get; set; }
        public bool? Status { get; set; }

        public ICollection<DayOperationRoutine> DayOperationRoutines { get; set; }
    }
}
