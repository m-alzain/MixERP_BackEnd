using ApplicationCore.Entities.Finance;
using ApplicationCore.Interfaces.Finance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Finance
{
    public class AccountRepository : EfRepository<Account>, IAccountRepository
    {
        public AccountRepository(SqlserverContext dbContext): base(dbContext)
        {            
        }
       
    }
}
