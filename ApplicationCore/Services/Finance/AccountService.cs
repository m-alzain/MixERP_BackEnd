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
//    public class AccountService : IAccountService
//    {       
//        protected readonly IAccountRepository _accountRepository;

//        public AccountService(IAccountRepository accountRepository)
//        {            
//            _accountRepository = accountRepository;
//        }

//        public async Task<int?> GetAccountIdByAccountNumberAsync(string tenant, string accountNumber)
//        {
//            var accountId = _accountRepository.GetSingleBySpec(new AccountSpecification( tenant:tenant, accountNumber:accountNumber))?.AccountId;           
//            return await Task.FromResult(accountId);
//        }

//        public async Task<IEnumerable<Account>> GetAsync(string tenant)
//        {
//            var accounts = _accountRepository.List(new AccountSpecification(tenant : tenant, isTransactionNode:true));
//            return await Task.FromResult(accounts);
//        }

//        public async Task<IEnumerable<Account>> GetNonConfidentialAsync(string tenant)
//        {
//            var accounts = _accountRepository.List(new AccountSpecification(tenant: tenant, isTransactionNode: true, confidential: false));
//            return await Task.FromResult(accounts);
//        }

//        public async Task<bool> IsCashAccountAsync(string tenant, string accountNumber)
//        {
//            var account = _accountRepository.GetSingleBySpec(new AccountSpecification(tenant : tenant, accountNumber : accountNumber, accountMasterId : 10101));
//            var hasCashAccount = account == null ? false : true;
//            return await Task.FromResult(hasCashAccount);
//        }
//    }
//}
