using ApplicationCore.Interfaces.Finance;
using Contracts.ApplicationState.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Finance.ViewModels;

namespace Web.Services
{
    public class JournalEntries
    {
        private ITransactionPostingService _transactionPostingServices;
        private ICashRepositoryService _cashRepositoryService;
        private IAccountService _accountService;
        public JournalEntries(
            ITransactionPostingService transactionPostingServices,
            ICashRepositoryService cashRepositoryService,
            IAccountService accountService
            )
        {
            _transactionPostingServices = transactionPostingServices;
            _cashRepositoryService = cashRepositoryService;
            _accountService = accountService;
        }

        public async Task<long> PostAsync(string tenant, TransactionPosting model, LoginView meta)
        {
            foreach (var item in model.Details)
            {
                if (item.Debit > 0 && item.Credit > 0)
                {
                    //throw new InvalidOperationException(I18N.InvalidData);
                    throw new InvalidOperationException("InvalidData");
                }

                if (item.Debit == 0 && item.Credit == 0)
                {
                    //throw new InvalidOperationException(I18N.InvalidData);
                    throw new InvalidOperationException("InvalidData");
                }

                if (item.Credit < 0 || item.Debit < 0)
                {
                    //throw new InvalidOperationException(I18N.InvalidData);
                    throw new InvalidOperationException("InvalidData");
                }

                if (item.Credit > 0)
                {
                    if (await _accountService.IsCashAccountAsync(tenant, item.AccountNumber))
                    {
                        if (await _cashRepositoryService.GetBalanceAsync(tenant, item.CashRepositoryCode, item.CurrencyCode) < item.Credit)
                        {
                            //throw new InvalidOperationException(I18N.InsufficientBalanceInCashRepository);
                            throw new InvalidOperationException("InsufficientBalanceInCashRepository");
                        }
                    }
                }
            }

            decimal drTotal = (from detail in model.Details select detail.LocalCurrencyDebit).Sum();
            decimal crTotal = (from detail in model.Details select detail.LocalCurrencyCredit).Sum();

            if (drTotal != crTotal)
            {
                //throw new InvalidOperationException(I18N.ReferencingSidesNotEqual);
                throw new InvalidOperationException("ReferencingSidesNotEqual");
            }

            //int decimalPlaces = CultureManager.GetCurrencyDecimalPlaces();
            int decimalPlaces = 2;

            if ((from detail in model.Details
                 where
                 decimal.Round(detail.Credit * detail.ExchangeRate, decimalPlaces) !=
                 decimal.Round(detail.LocalCurrencyCredit, decimalPlaces) ||
                 decimal.Round(detail.Debit * detail.ExchangeRate, decimalPlaces) !=
                 decimal.Round(detail.LocalCurrencyDebit, decimalPlaces)
                 select detail).Any())
            {
                //throw new InvalidOperationException(I18N.ReferencingSidesNotEqual);
                throw new InvalidOperationException("ReferencingSidesNotEqual");
            }


            long tranId = await _transactionPostingServices.AddAsync(tenant, meta, model).ConfigureAwait(true);
            return tranId;            
        }
    }
}
