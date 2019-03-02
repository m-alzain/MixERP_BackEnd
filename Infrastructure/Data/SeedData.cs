using ApplicationCore.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SeedData
    {
        public static void SeedAsync(SqlserverContext sqlserverContext)
        {
            
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                if (!sqlserverContext.EntityTypes.Any())
                {
                    sqlserverContext.EntityTypes.AddRange(GetPreconfiguredEntityTypes());
                    sqlserverContext.SaveChanges();
                }
               
        }

        static IEnumerable<EntityType> GetPreconfiguredEntityTypes()
        {
            return new List<EntityType>()
            {
                new EntityType() { Id = Guid.Parse("91CF4A1D-AAEA-43EE-AD9A-B06A53130455"),EntityName = "Roles", ModuleName = "account", Url= "account/roles",Icon=""},
                new EntityType() { Id = Guid.Parse("17B8BC60-1040-48F2-B62F-D27EC2F573C5"),EntityName = "Users", ModuleName = "account", Url= "account/users",Icon=""},
                new EntityType() { Id = Guid.Parse("9316C037-50C2-48B6-BC89-F99AAFEC2457"),EntityName = "Tenants", ModuleName = "account", Url= "account/tenants",Icon=""},
            };
        }
    }
}
