using ApplicationCore.Interfaces.Finance;
using Contracts.ApplicationState.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Finance.ViewModels;
using Web.Services;
using Contracts.Finance.QueryModels;
using Contracts.Finance.DTO;

namespace Web.Controllers.Api.Finance
{
    public class JournalEntryController : BaseApiController
    {
        private IAccountService _accountService;
        private ICashRepositoryService _cashRepositoryService;
        private JournalEntries _journalEntriese;
        private IJournalService _journalService;

        public JournalEntryController(
            IAccountService accountService, 
            ICashRepositoryService cashRepositoryService, 
            JournalEntries journalEntriese,
            IJournalService journalService)
        {
            _accountService = accountService;
            _cashRepositoryService = cashRepositoryService;
            _journalEntriese = journalEntriese;
            _journalService = journalService;
        }

        [Route("dashboard/finance/tasks/journal/entry/new")]
        [HttpPost]
        public async Task<ActionResult<long>> PostAsync([FromBody] TransactionPosting model)
        {
            //var meta = await AppUsers.GetCurrentAsync().ConfigureAwait(true);
            var meta = new LoginView {
                UserId = 1,
                IsAdministrator = true,
                LoginId = 1,
                OfficeId = 1,
                RoleId = 1,
                CurrencyCode = "USD"
            };
            try
            {
                long tranId = await _journalEntriese.PostAsync(null, model, meta);
                return tranId;
            }
            catch (Exception e)
            {
                return 0;
            }
                     
        }

        [Route("dashboard/finance/tasks/journal/view")]
        [HttpPost]
        public async Task<ActionResult<List<JournalView>>> GetAsync([FromBody] JournalViewQuery query)
        {
            //var appUser = await AppUsers.GetCurrentAsync().ConfigureAwait(true);
            var appUser = new LoginView
            {
                UserId = 1,
                IsAdministrator = true,
                LoginId = 1,
                OfficeId = 1,
                RoleId = 1,
                CurrencyCode = "USD"
            };

            query.OfficeId = appUser.OfficeId;
            query.UserId = appUser.UserId;

            query.From = query.From == DateTime.MinValue ? DateTime.Today : query.From;
            query.To = query.To == DateTime.MinValue ? DateTime.Today : query.To;

            

            try
            {
                var model = await _journalService.GetJournalViewAsync(null, query);
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // V2 Code       
        [Route("finance/tasks/journal/view")]
        [HttpPost]
        public async Task<ActionResult<List<JournalEntryDto>>> GetJournalEntriesAsync()
        {
            //var appUser = await AppUsers.GetCurrentAsync().ConfigureAwait(true);            

            try
            {
                var model = await _journalService.GetJournalEntriesAsync(null);
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
