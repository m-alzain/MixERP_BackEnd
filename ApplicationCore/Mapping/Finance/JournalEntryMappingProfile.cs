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
            //CreateMap<TransactionMaster, JournalEntryDto>()
            //    .ForMember(dto => dto.JournalEntryLines, conf => conf.MapFrom(tm => tm.TransactionDetails))
            //    .ForMember(dto => dto.CostCenter, conf => conf.MapFrom(tm => tm.CostCenter.CostCenterName))
            //    .ForMember(dto => dto.Office, conf => conf.MapFrom(tm => tm.Office.OfficeName))
            //    .ForMember(dto => dto.Status, conf => conf.MapFrom(tm => tm.VerificationStatus.VerificationStatusName))
            //    .ForMember(dto => dto.VerifiedByUser, conf => conf.MapFrom(tm => tm.VerifiedByUser.Name))
            //.ReverseMap()
            //.ForPath(tm => tm.CostCenter.CostCenterName, opt => opt.Ignore())
            //.ForPath(tm => tm.Office.OfficeName, opt => opt.Ignore())
            //.ForPath(tm => tm.VerificationStatus, opt => opt.Ignore())
            //.ForPath(tm => tm.VerifiedByUser.Name, opt => opt.Ignore());

            //CreateMap<TransactionDetail, JournalEntryLineDto>()
            //    .ForMember(dto => dto.Account, conf => conf.MapFrom(td => td.Account.AccountName))
            //.ReverseMap()
            //.ForPath(td => td.Account.AccountName, opt => opt.Ignore());
        }
    }
}
