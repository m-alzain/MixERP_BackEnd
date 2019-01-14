using ApplicationCore.Entities.Finance;
using AutoMapper;
using Contracts.Finance.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Mapping.Finance
{
    public class JournalEntryMappingProfile : Profile
    {
        public JournalEntryMappingProfile()
        {           
            CreateMap<TransactionMaster, JournalEntryDto>()
                .ForMember(dto => dto.JournalEntryLines, conf => conf.MapFrom(tm => tm.TransactionDetails));
        }
    }
}
