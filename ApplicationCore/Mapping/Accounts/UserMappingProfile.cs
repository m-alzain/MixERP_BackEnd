using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Auth;
using ApplicationCore.Entities.Core;
using AutoMapper;
using Contracts.Accounts;
using Contracts.Auth;
using Contracts.Core;
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
                .ForMember(dto => dto.Roles, conf => conf.MapFrom(u => u.RoleUsers.Select(ru => ru.Role)))
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




            CreateMap<EntityType, EntityTypeDto>()               
            .ReverseMap();

            CreateMap<GroupEntityAccessPolicy, GroupEntityAccessPolicyDto>()
                .ForMember(dto => dto.RoleName, conf => conf.MapFrom(u => u.Role.RoleName))
            .ReverseMap()
            .ForPath(tm => tm.Role.RoleName, opt => opt.Ignore());

            CreateMap<Role, RoleDto>()
           .ReverseMap();
        }
    }
}
