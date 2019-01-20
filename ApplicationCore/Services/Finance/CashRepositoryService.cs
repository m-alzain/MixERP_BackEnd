//using ApplicationCore.Entities.Finance;
//using ApplicationCore.Interfaces;
//using ApplicationCore.Interfaces.Finance;
//using ApplicationCore.Specifications;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace ApplicationCore.Services.Finance
//{
//    public class CashRepositoryService : ICashRepositoryService
//    {
//        protected readonly IAsyncRepository<CashRepository> _casnAsyncRepository;
//        protected readonly IRepository<CashRepository> _casnRepository;
//        protected readonly ICommandRepository _commandRepository;
//        public CashRepositoryService(
//            IAsyncRepository<CashRepository> casnAsyncRepository, 
//            IRepository<CashRepository> casnRepository,
//            ICommandRepository commandRepository)
//        {
//            _casnAsyncRepository = casnAsyncRepository;
//            _casnRepository = casnRepository;
//            _commandRepository = commandRepository;
//        }
//        public async Task<decimal> GetBalanceAsync(string tenant, string cashRepositoryCode, string currencyCode)
//        {
//            const string sql = "SELECT finance.get_cash_repository_balance(finance.get_cash_repository_id_by_cash_repository_code(@p0), @p1) as Value";            
//            return await _commandRepository.GetDecimalQueryAsync(sql,new object[] { cashRepositoryCode, currencyCode });
//        }

//        public async Task<int?> GetCashRepositoryIdByCashRepositoryCodeAsync(string tenant, string cashRepositoryCode)
//        {
//            var cashRepositoryId = _casnRepository.GetSingleBySpec(new CashRepositorySpecification(tenant, cashRepositoryCode))?.CashRepositoryId;
//            return await Task.FromResult(cashRepositoryId);
//        }
//    }
//}
