using ApplicationCore.Queries.Finance;
using ApplicationCore.Queries.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICommandRepository
    {
        int ExecuteSqlCommand(string command, object[] param);
        Task<decimal> GetDecimalQueryAsync(string sql, object [] param);
        Task<List<EntityColumnQuery>> GetEntityColumnQueryAsync(string sql, object[] param);
        Task<List<JournalViewQuery>> GetJournalViewQueryAsync(string sql, object[] param);
    }
}
