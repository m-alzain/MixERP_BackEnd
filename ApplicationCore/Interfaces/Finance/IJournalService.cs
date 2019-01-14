using Contracts.Finance.DTO;
using Contracts.Finance.QueryModels;
using Contracts.Finance.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Finance
{
    public interface IJournalService
    {
        Task<long> VerifyTransactionAsync(string tenant, Verification model);
        Task<List<JournalView>> GetJournalViewAsync(string tenant, JournalViewQuery query);



        // V2 code
        Task<List<JournalEntryDto>> GetJournalEntriesAsync(JournalViewQuery query);
    }
}
