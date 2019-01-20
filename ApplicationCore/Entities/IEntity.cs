using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
