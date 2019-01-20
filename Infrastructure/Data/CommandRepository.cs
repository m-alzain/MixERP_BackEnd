//using ApplicationCore.Interfaces;
//using ApplicationCore.Queries.Finance;
//using ApplicationCore.Queries.Forms;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.Data
//{
//    public class CommandRepository : ICommandRepository
//    {
//        protected readonly SqlserverContext _dbContext;

//        public CommandRepository(SqlserverContext dbContext)
//        {
//            _dbContext = dbContext;
//        }       

//        public int ExecuteSqlCommand(string command, object[] param)
//        {
//            return _dbContext.Database.ExecuteSqlCommand(command, param);
//        }

//        public async Task<decimal> GetDecimalQueryAsync(string sql, object[] param)
//        {
//            var result = await _dbContext.DecimalQuery.FromSql(sql, param).FirstOrDefaultAsync();
//            return result.Value;
//        }

//        public async Task<List<EntityColumnQuery>> GetEntityColumnQueryAsync(string sql, object[] param)
//        {
//            var result = await _dbContext.EntityColumnQuery.FromSql(sql, param).ToListAsync();
//            return result;
//        }

//        public async Task<List<JournalViewQuery>> GetJournalViewQueryAsync(string sql, object[] param)
//        {
//            var result = await _dbContext.JournalViewQuery.FromSql(sql, param).ToListAsync();
//            return result;
//        }

//    }
//}
