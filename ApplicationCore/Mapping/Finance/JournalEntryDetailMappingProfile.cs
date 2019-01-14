using ApplicationCore.Entities.Finance;
using AutoMapper;
using Contracts.Finance.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Mapping.Finance
{
    public class JournalEntryDetailMappingProfile : Profile
    {
        public JournalEntryDetailMappingProfile()
        {
            CreateMap<TransactionDetail, JournalEntryDto>();
        }
    }
}
