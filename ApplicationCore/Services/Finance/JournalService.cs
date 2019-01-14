using ApplicationCore.Entities.Finance;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Finance;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts.Finance.DTO;
using Contracts.Finance.QueryModels;
using Contracts.Finance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services.Finance
{
    public class JournalService : IJournalService
    {
        protected readonly IRepository<TransactionMaster> _transactionMasterRepository;
        protected readonly ICommandRepository _commandRepository;
        protected readonly IMapper _mapper;

        public JournalService(ICommandRepository commandRepository, IRepository<TransactionMaster> transactionMasterRepository, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _transactionMasterRepository = transactionMasterRepository;
            _mapper = mapper;
        }        

        public async Task<List<JournalView>> GetJournalViewAsync(string tenant, JournalViewQuery query)
        {
            var sql = "SELECT * FROM finance.get_journal_view(@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14)";
            var journalViewQuery = await _commandRepository.GetJournalViewQueryAsync(sql,new object[] {
                query.UserId, query.OfficeId, query.From, query.To, query.TranId, query.TranCode, query.Book,
                query.ReferenceNumber, query.Amount, query.StatementReference, query.PostedBy, query.Office,
                query.Status, query.VerifiedBy, query.Reason });
            return journalViewQuery.Select(q => new JournalView
            {
                TransactionMasterId = q.transaction_master_id,
                TransactionCode = q.transaction_code,
                Book = q.book,
                ValueDate = q.value_date,
                BookDate = q.book_date,
                ReferenceNumber = q.reference_number,
                StatementReference = q.statement_reference,
                Amount = q.amount,
                PostedBy = q.posted_by,
                Office = q.office,
                Status = q.status,
                VerifiedBy = q.verified_by,
                VerifiedOn = q.verified_on,
                Reason = q.reason,
                TransactionTs = q.transaction_ts
            }).ToList();
        }

        public Task<long> VerifyTransactionAsync(string tenant, Verification model)
        {
            throw new NotImplementedException();
        }

        // V2 Code
        public async Task<List<JournalEntryDto>> GetJournalEntriesAsync(JournalViewQuery query)
        {
            var result = _transactionMasterRepository.ListAllQueryable().ProjectTo<JournalEntryDto>().ToList();
            return await Task.FromResult(result);
        }
    }
}
