using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public interface ITenant
    {
        Guid TenantId { get; set; }
    }
}
