using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Finance;
using Contracts.Finance.DTO;
using Contracts.Finance.QueryModels;
using Contracts.Finance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.Finance
{
    public class JournalService : IJournalService
    {
        protected readonly ICommandRepository _commandRepository;
        public JournalService(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
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
    }
}
