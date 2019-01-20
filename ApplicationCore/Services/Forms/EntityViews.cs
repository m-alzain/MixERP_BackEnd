//using ApplicationCore.Interfaces;
//using ApplicationCore.Queries.Forms;
//using ApplicationCore.Utilities.Extensions;
//using Contracts.Finance.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ApplicationCore.Services.Forms
//{
//    public class EntityViews
//    {
//        private readonly ICommandRepository _commandRepository;
        
//        public EntityViews(ICommandRepository commandRepository)
//        {
//            _commandRepository = commandRepository;            
//        }

//        public async Task<EntityView> GetAsync(string tenant, string primaryKey, string schemaName, string tableName)
//        {
//            string sql = "EXECUTE dbo.poco_get_table_function_definition @p0, @p1";

//            //var columns = (await Factory.GetAsync<EntityColumn>(tenant, sql, schemaName, tableName).ConfigureAwait(false)).ToList();
//            var entityColumnQuery = await _commandRepository.GetEntityColumnQueryAsync(sql, new object[] { schemaName, tableName });
//            var columns = entityColumnQuery.Select(e => new EntityColumn
//            {
//                ColumnName = e.column_name,
//                DataType = e.data_type,
//                DbDataType = e.db_data_type,
//                Nullable = e.nullable,
//                PrimaryKey = e.primary_key,
//                MaxLength = e.max_length,
//                IsSerial = e.is_serial,
//                Value = e.value
//            }).ToList(); 
            
//            var candidate = columns.FirstOrDefault(x => x.PrimaryKey.Or("").ToUpperInvariant().StartsWith("Y"));

//            if (candidate != null)
//            {
//                primaryKey = candidate.ColumnName;
//            }

//            var meta = new EntityView
//            {
//                PrimaryKey = primaryKey,
//                Columns = columns
//            };

//            return meta;
//        }
//    }
//}
