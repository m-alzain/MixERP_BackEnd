using ApplicationCore.Entities.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Entities.Core
{
    public class EntityType : IEntity
    {

        #region IEntity

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        #endregion

       
        public string ModuleName { get; set; }
        public string EntityName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
       
        public ICollection<GroupEntityAccessPolicy> GroupEntityAccessPolicies { get; set; }        
    }
}
