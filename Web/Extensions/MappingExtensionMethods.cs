using ApplicationCore.Entities.Accounts;
using Contracts.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Extensions
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
    }
}
