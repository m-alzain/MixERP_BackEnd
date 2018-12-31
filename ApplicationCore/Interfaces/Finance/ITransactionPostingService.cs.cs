using Contracts.ApplicationState.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Finance.ViewModels;

namespace ApplicationCore.Interfaces.Finance
{
    public interface ITransactionPostingService
    {
        Task WithdrawAsync(string tenant, string reason, int userId, long tranId, int officeId);
        Task<bool> CanPostTransactionAsync(string tenant, long loginId, int userId, int officeId, string transactionBook, DateTime valueDate);
        Task<long> AddAsync(string tenant, LoginView userInfo, TransactionPosting model);       
    }
}
