using Contracts.Accounts;
using Contracts.Auth;
using Contracts.Core;
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
        Task<UserDto> GetUserByEmail(string email);
        Task<UserDto> GetAuthContext();
        Task<UserDto> CreateUser(UserDto userDto, string officeId);
        Task<UserDto> CreateInitialUser(UserDto userDto);
        Task<UserDto> UpdateContextUser(UserDto userDto);
        Task<UserDto> UpdateUser(UserDto userDto, string officeId);
        Task<UserDto> AddOfficeUser(UserDto userDto, string officeId);
        Task<string> DeleteUser(string userId);

        Task<IList<TenantDto>> GetAllTenants();
        Task<IList<TenantDto>> GetUserTenants();
        Task<TenantDto> GetTenant(string tenantId);
        Task<TenantDto> CreateTenant(TenantDto tenantDto);
        Task<TenantDto> UpdateTenant(TenantDto tenantDto);
        Task<string> DeleteTenant(string tenantId);

        Task<IList<OfficeDto>> GetAllOffices();      
        Task<IList<OfficeDto>> GetTenantOffices(string tenantId);
        Task<IList<OfficeDto>> GetUserOffices(string userId);
        Task<OfficeDto> GetOffice(string officeId);
        Task<OfficeDto> CreateOffice(OfficeDto officeDto);
        Task<string> DeleteOffice(string officeId);

        Task<IList<RoleDto>> GetAllRoles();
        Task<IList<RoleDto>> GetTenantRoles(string tenantId);
        Task<IList<RoleDto>> GetOfficeRoles(string officeId);
        Task<RoleDto> GetRole(string roloeId);
        Task<RoleDto> CreateRole(RoleDto roleDto);
        Task<UserDto> UpdateRoleUser(string officeId, string userId, string roleId );
        Task<string> DeleteRole(string roleId);

        Task<IList<EntityTypeDto>> GetAllEntityTypes();
        Task<EntityTypeDto> GetEntityType(string entityTypeId);
        Task<EntityTypeDto> CreateEntityType(EntityTypeDto entityTypeDto);
        Task<EntityTypeDto> UpdateEntityType(EntityTypeDto entityTypeDto);
        Task<string> DeleteEntityType(string entityTypeId);

        Task<GroupEntityAccessPolicyDto> CreateGroupEntityAccessPolicy(GroupEntityAccessPolicyDto groupEntityAccessPolicyDto);
        Task<GroupEntityAccessPolicyDto> UpdateGroupEntityAccessPolicy(GroupEntityAccessPolicyDto groupEntityAccessPolicyDto);
        Task<GroupEntityAccessPolicyDto> DeleteGroupEntityAccessPolicy(string groupEntityAccessPolicyId);


    }
}
