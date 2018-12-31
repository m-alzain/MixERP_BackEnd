using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Finance
{
    public interface ICashRepositoryService
    {
        Task<int?> GetCashRepositoryIdByCashRepositoryCodeAsync(string tenant, string cashRepositoryCode);
        Task<decimal> GetBalanceAsync(string tenant, string cashRepositoryCode, string currencyCode);
    }
}
