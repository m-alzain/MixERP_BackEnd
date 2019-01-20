using ApplicationCore.Entities.Accounts;
using AutoMapper;
using Contracts.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Mapping.Accounts
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dto => dto.Offices, conf => conf.MapFrom(u => u.OfficeUsers.Select(tou => tou.Office)))
            .ReverseMap()
            .ForPath(tm => tm.OfficeUsers, opt => opt.Ignore());

            CreateMap<Tenant, TenantDto>()                
                .ForMember(dto => dto.Offices, conf => conf.MapFrom(t => t.Offices))
            .ReverseMap()
            .ForPath(t => t.Offices, opt => opt.Ignore());

            //CreateMap<TenantDto, Tenant>()
            //    .ForMember(t => t.TenantOfficeUsers, opt => opt.Ignore())
            //    .ForMember(dto => dto.Offices, opt => opt.Ignore());

            CreateMap<Office, OfficeDto>()
                .ForMember(dto => dto.Tenant, conf => conf.MapFrom(o => o.Tenant.TenantName))
                .ForMember(dto => dto.ParentOffice, conf => conf.MapFrom(o => o.ParentOffice.OfficeName))
            .ReverseMap()
            .ForPath(o => o.Tenant.TenantName, opt => opt.Ignore())
            .ForPath(o => o.ParentOffice.OfficeName, opt => opt.Ignore());


            // in case we want to add new tenant and there is no office; an office with tenant info will be added
            

        }
    }
}
