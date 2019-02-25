using ApplicationCore.Entities.Accounts;
using Contracts.Accounts;
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
        }

        public static void MappOfficeDto(this Office office, OfficeDto officeDto)
        {
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

        }
    }
}
