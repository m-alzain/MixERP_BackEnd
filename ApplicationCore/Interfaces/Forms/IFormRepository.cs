using ApplicationCore.Services.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Forms
{
    public interface IFormRepository
    {
        Task<EntityView> GetMetaAsync(string schemaName, string tableName, string tenant, long loginId, int userId);
    }
}
