using Contracts.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Accounts
{
    public interface IUserService
    {
        Task<IList<UserDto>> GetAllUsers();
        Task<IList<UserDto>> GetTenantUsers(string tenantId);
        Task<IList<UserDto>> GetOfficeUsers(string officeId);
        Task<UserDto> GetUser(string userId);
        Task<UserDto> CreateUser(UserDto userDto, string officeId);
        Task<UserDto> AddUser(string userId, string officeId);
        Task<string> DeleteUser(string userId);

        Task<IList<TenantDto>> GetAllTenants();
        Task<IList<TenantDto>> GetUserTenants(string userId);
        Task<TenantDto> GetTenant(string tenantId);
        Task<TenantDto> CreateTenant(TenantDto tenantDto);
        Task<string> DeleteTenant(string tenantId);

        Task<IList<OfficeDto>> GetAllOffices();      
        Task<IList<OfficeDto>> GetTenantOffices(string tenantId);
        Task<IList<OfficeDto>> GetUserOffices(string userId);
        Task<OfficeDto> GetOffice(string officeId);
        Task<OfficeDto> CreateOffice(OfficeDto officeDto);
        Task<string> DeleteOffice(string officeId);


    }
}
