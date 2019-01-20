using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public interface IAuditable
    {
        Guid? CreatedByUserId { get; set; }
        DateTimeOffset? CreatedOn { get; set; }
        Guid? UpdatedByUserId { get; set; }
        DateTimeOffset? UpdatedOn { get; set; }
    }
}
