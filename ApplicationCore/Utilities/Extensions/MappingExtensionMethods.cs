using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Auth;
using Contracts.Accounts;
using Contracts.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Utilities.Extensions
{
    public static class MappingExtensionMethods
    {
        public static void MappTenantDto(this Tenant tenant, TenantDto tenantDto)
        {
            //tenant.Id = tenantDto.Id;
            tenant.TenantCode = tenantDto.TenantCode;
            tenant.TenantName = tenantDto.TenantName;
            tenant.RegistrationDate = tenantDto.RegistrationDate;
            tenant.CurrencyCode = tenantDto.CurrencyCode;
            tenant.AddressLine1 = tenantDto.AddressLine1;
            tenant.AddressLine2 = tenantDto.AddressLine2;
            tenant.Street = tenantDto.Street;
            tenant.State = tenantDto.State;
            tenant.City = tenantDto.City;
            tenant.ZipCode = tenantDto.ZipCode;
            tenant.Country = tenantDto.Country;
            tenant.Phone = tenantDto.Phone;
            tenant.Fax = tenantDto.Fax;
            tenant.Email = tenantDto.Email;
            tenant.Url = tenantDto.Url;
            tenant.Logo = tenantDto.Logo;
            tenant.RegistrationNumber = tenantDto.RegistrationNumber;

            tenant.CreatedByUserId = tenantDto.CreatedByUserId;
            tenant.CreatedOn = tenantDto.CreatedOn;
            tenant.UpdatedByUserId = tenantDto.UpdatedByUserId;
            tenant.UpdatedOn = tenantDto.UpdatedOn;           
        }

        public static void MappOfficeDto(this Office office, OfficeDto officeDto)
        {
            //office.Id = officeDto.Id;
            //office.TenantId = officeDto.TenantId;
            office.OfficeCode = officeDto.OfficeCode;
            office.OfficeName = officeDto.OfficeName;
            office.NickName = officeDto.NickName;
            office.RegistrationDate = officeDto.RegistrationDate;
            office.CurrencyCode = officeDto.CurrencyCode;
            office.PoBox = officeDto.PoBox;
            office.AddressLine1 = officeDto.AddressLine1;
            office.AddressLine2 = officeDto.AddressLine2;
            office.Street = officeDto.Street;
            office.State = officeDto.State;
            office.City = officeDto.City;
            office.ZipCode = officeDto.ZipCode;
            office.Country = officeDto.Country;
            office.Phone = officeDto.Phone;
            office.Fax = officeDto.Fax;
            office.Email = officeDto.Email;
            office.Url = officeDto.Url;
            office.Logo = officeDto.Logo;
            office.ParentOfficeId = officeDto.ParentOfficeId;
            office.RegistrationNumber = officeDto.RegistrationNumber;
            office.PanNumber = officeDto.PanNumber;
            office.AllowTransactionPosting = officeDto.AllowTransactionPosting;

            office.CreatedByUserId = officeDto.CreatedByUserId;
            office.CreatedOn = officeDto.CreatedOn;
            office.UpdatedByUserId = officeDto.UpdatedByUserId;
            office.UpdatedOn = officeDto.UpdatedOn;

        }

        public static void MappRoleDto(this Role role, RoleDto roleDto)
        {
            //role.Id = roleDto.Id;
            //role.OfficeId = roleDto.OfficeId;
            role.RoleName = roleDto.RoleName;
            role.IsAdministrator = roleDto.IsAdministrator;
            role.Deleted = roleDto.Deleted;
            
            role.CreatedByUserId = roleDto.CreatedByUserId;
            role.CreatedOn = roleDto.CreatedOn;
            role.UpdatedByUserId = roleDto.UpdatedByUserId;
            role.UpdatedOn = roleDto.UpdatedOn;
        }

        public static void MappGroupEntityAccessPolicyDto(this GroupEntityAccessPolicy groupEntityAccessPolicy, GroupEntityAccessPolicyDto groupEntityAccessPolicyDto)
        {
            //groupEntityAccessPolicy.Id = groupEntityAccessPolicyDto.Id;
            groupEntityAccessPolicy.EntityTypeId = groupEntityAccessPolicyDto.EntityTypeId;
            groupEntityAccessPolicy.RoleId = groupEntityAccessPolicyDto.RoleId;
            groupEntityAccessPolicy.AllowAccess = groupEntityAccessPolicyDto.AllowAccess;
            groupEntityAccessPolicy.AccessType = groupEntityAccessPolicyDto.AccessType;
            groupEntityAccessPolicy.Deleted = groupEntityAccessPolicyDto.Deleted;

            groupEntityAccessPolicy.CreatedByUserId = groupEntityAccessPolicyDto.CreatedByUserId;
            groupEntityAccessPolicy.CreatedOn = groupEntityAccessPolicyDto.CreatedOn;
            groupEntityAccessPolicy.UpdatedByUserId = groupEntityAccessPolicyDto.UpdatedByUserId;
            groupEntityAccessPolicy.UpdatedOn = groupEntityAccessPolicyDto.UpdatedOn;
        }
    }
}
