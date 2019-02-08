using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Core
{
    public class EntityTypeDto
    {
        public Guid Id { get; set; }

        public string ModuleName { get; set; }
        public string EntityName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
