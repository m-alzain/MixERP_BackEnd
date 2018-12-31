using ApplicationCore.Entities.Finance;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Finance;
using Contracts.ApplicationState.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Finance.ViewModels;

namespace ApplicationCore.Services.Finance
{
    public class TransactionPostingService : ITransactionPostingService
    {
        protected readonly IAsyncRepository<TransactionMaster> _transactionMasterAsyncRepository;
        protected readonly IAsyncRepository<TransactionDetail> _transactionDetailAsyncRepository;
        protected readonly IAsyncRepository<TransactionDocument> _transactionDocumentAsyncRepository;
        protected readonly IAccountService _accountService;
        protected readonly ICashRepositoryService _cashRepositoryService;
        protected readonly ICommandRepository _commandRepository;


        public TransactionPostingService(
            IAsyncRepository<TransactionMaster> transactionMasterAsyncRepository,
            IAsyncRepository<TransactionDetail> transactionDetailAsyncRepository,
            IAsyncRepository<TransactionDocument> transactionDocumentAsyncRepository,
            IAccountService accountService,
            ICashRepositoryService cashRepositoryService,
            ICommandRepository commandRepository
            )
        {
            _transactionMasterAsyncRepository = transactionMasterAsyncRepository;
            _transactionDetailAsyncRepository = transactionDetailAsyncRepository;
            _transactionDocumentAsyncRepository = transactionDocumentAsyncRepository;
            _accountService = accountService;
            _cashRepositoryService = cashRepositoryService;
            _commandRepository = commandRepository;
        }

        public async Task<long> AddAsync(string tenant, LoginView userInfo, TransactionPosting model)
        {
            long transactionMasterId = 0;
            string bookName = "Journal Entry";
            //bool canPost = await CanPostTransactionAsync(tenant, userInfo.LoginId, userInfo.UserId, userInfo.OfficeId, bookName, model.ValueDate).ConfigureAwait(false);
            bool canPost = true;
            if (!canPost)
            {
                return transactionMasterId;
            }


           
            var master = new TransactionMaster
            {
                Book = bookName,
                ValueDate = model.ValueDate,
                BookDate = model.BookDate,
                TransactionTs = DateTimeOffset.UtcNow,
                TransactionCode = string.Empty,
                LoginId = userInfo.LoginId,
                UserId = userInfo.UserId,
                OfficeId = userInfo.OfficeId,
                CostCenterId = model.CostCenterId,
                ReferenceNumber = model.ReferenceNumber,
                StatementReference = string.Empty,
                VerificationStatusId = 0,
                VerificationReason = string.Empty,
                AuditUserId = userInfo.UserId,
                AuditTs = DateTimeOffset.UtcNow,
                Deleted = false
            };

            await _transactionMasterAsyncRepository.AddAsync(master);
            transactionMasterId = master.TransactionMasterId;
            //var insertedId = db.InsertAsync("finance.transaction_master", "transaction_master_id", true, master).ConfigureAwait(true);
            //transactionMasterId = insertedId.To<long>();



            foreach (var line in model.Details)
            {
                decimal amountInCurrency;
                string tranType;
                decimal amountInLocalCurrency;

                if (line.Credit.Equals(0) && line.Debit > 0)
                {
                    tranType = "Dr";
                    amountInCurrency = line.Debit;
                    amountInLocalCurrency = line.LocalCurrencyDebit;
                }
                else
                {
                    tranType = "Cr";
                    amountInCurrency = line.Credit;
                    amountInLocalCurrency = line.LocalCurrencyCredit;
                }


                var detail = new TransactionDetail
                {
                    TransactionMasterId = transactionMasterId,
                    ValueDate = model.ValueDate,
                    BookDate = model.BookDate,
                    TranType = tranType,
                    AccountId = (await _accountService.GetAccountIdByAccountNumberAsync(tenant, line.AccountNumber)).Value,
                    StatementReference = line.StatementReference,
                    CashRepositoryId = await _cashRepositoryService.GetCashRepositoryIdByCashRepositoryCodeAsync(tenant, line.CashRepositoryCode).ConfigureAwait(false),
                    CurrencyCode = line.CurrencyCode,
                    AmountInCurrency = amountInCurrency,
                    OfficeId = userInfo.OfficeId,
                    LocalCurrencyCode = userInfo.CurrencyCode,
                    Er = line.ExchangeRate,
                    AmountInLocalCurrency = amountInLocalCurrency,
                    AuditUserId = userInfo.UserId,
                    AuditTs = DateTimeOffset.UtcNow
                };

                //await db.InsertAsync("finance.transaction_details", "transaction_detail_id", true, detail).ConfigureAwait(false);
                await _transactionDetailAsyncRepository.AddAsync(detail);
            }

            if (model.Attachements != null && model.Attachements.Count > 0)
            {
                foreach (var item in model.Attachements)
                {
                    var document = new TransactionDocument
                    {
                        TransactionMasterId = transactionMasterId,
                        OriginalFileName = item.OriginalFileName,
                        FileExtension = item.FileExtension,
                        FilePath = item.FilePath,
                        Memo = item.Memo,
                        AuditUserId = userInfo.UserId,
                        AuditTs = DateTimeOffset.UtcNow,
                        Deleted = false
                    };

                    //await db.InsertAsync("finance.transaction_documents", "document_id", true, document).ConfigureAwait(false);
                    await _transactionDocumentAsyncRepository.AddAsync(document);
                }
            }

            var query = "EXECUTE finance.auto_verify @p0, @p1";
            _commandRepository.ExecuteSqlCommand(query, new object [] { transactionMasterId, userInfo.UserId });
            //var sql = new Sql(query, transactionMasterId, userInfo.UserId);
            //await db.NonQueryAsync(sql).ConfigureAwait(false);
              
            return transactionMasterId;
        }

        public Task<bool> CanPostTransactionAsync(string tenant, long loginId, int userId, int officeId, string transactionBook, DateTime valueDate)
        {
            throw new NotImplementedException();
        }

        public Task WithdrawAsync(string tenant, string reason, int userId, long tranId, int officeId)
        {
            throw new NotImplementedException();
        }
    }
}
