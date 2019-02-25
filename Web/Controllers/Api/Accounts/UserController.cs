﻿using ApplicationCore.Interfaces.Accounts;
using Contracts.Accounts;
using Contracts.Auth;
using Contracts.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers.Api.Accounts
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        

        public UserController(
            IUserService userService)
        {
            _userService = userService;
        }

        #region User part

        [Route("account/users")]
        [HttpGet]
        public async Task<IList<UserDto>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        [Route("account/tenant/users/get/{tenantId}")]
        [HttpGet]
        public async Task<IList<UserDto>> GetTenantUsers(string tenantId)
        {
            return await _userService.GetTenantUsers(tenantId);
        }

        [Route("account/office/users/{officeId}")]
        [HttpGet]
        public async Task<IList<UserDto>> GetOfficeUsers(string officeId) // in use
        {
            return await _userService.GetOfficeUsers(officeId);
        }

        [Route("account/users/authcontext")]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetAuthContext()
        {
            return await _userService.GetAuthContext();
        }

        [Route("account/users/getbyemail/{email}")]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUserByEmail(string email)
        {
            return await _userService.GetUserByEmail(email);
        }

        [Route("account/users")]
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateInitialUser([FromBody] UserDto userDto)
        {
            return await _userService.CreateInitialUser(userDto);
        }

        [Route("account/users/{officeId}")] // in use
        [HttpPut]
        public async Task<ActionResult<UserDto>> UpdateUser([FromBody] UserDto userDto, string officeId) // in use
        {
            return await _userService.UpdateUser(userDto, officeId);
        }

        [Route("account/users/{officeId}")] // in use
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto userDto, string officeId) // in use
        {
            return await _userService.CreateUser(userDto, officeId);
        }        

        [Route("account/users/delete/{userId}")]
        [HttpDelete]
        public async Task<ActionResult<string>> DeleteUser(string userId)
        {
            return await _userService.DeleteUser(userId);
        }

        #endregion

        #region Tenant part

        [Route("account/tenants")]  // for super admin
        [HttpGet]
        public async Task<IList<TenantDto>> GetAllTenants()
        {
            return await _userService.GetAllTenants();
        }
        
        [Route("account/user/tenants")] // in use
        [HttpGet]
        public async Task<IList<TenantDto>> GetUserTenants()
        {
            return await _userService.GetUserTenants();
        }

        [Route("account/tenants/get/{tenantId}")]
        [HttpGet]
        public async Task<TenantDto> GetTenant(string tenantId)
        {
            return await _userService.GetTenant(tenantId);
        }

        [Route("account/tenants")] // in use
        [HttpPost]
        public async Task<TenantDto> CreateTenant([FromBody] TenantDto tenantDto)
        {
            return await _userService.CreateTenant(tenantDto);
        }

        [Route("account/tenants")] // in use
        [HttpPut]
        public async Task<TenantDto> UpdateTenant([FromBody] TenantDto tenantDto)
        {
            return await _userService.UpdateTenant(tenantDto);
        }

        #endregion

        #region Office part

        [Route("account/offices/get")]
        [HttpGet]
        public async Task<IList<OfficeDto>> GetAllOffices()
        {
            return await _userService.GetAllOffices();
        }

        [Route("account/tenant/offices/get/{tenantId}")]
        [HttpGet]
        public async Task<IList<OfficeDto>> GetTenantOffices(string tenantId)
        {
            return await _userService.GetTenantOffices(tenantId);
        }               

        [Route("account/user/offices/get/{userId}")]
        [HttpGet]
        public async Task<IList<OfficeDto>> GetUserOffices(string userId)
        {
            return await _userService.GetUserOffices(userId);
        }

        [Route("account/offices/create")]
        [HttpPost]
        public async Task<ActionResult<OfficeDto>> CreateOffice([FromBody] OfficeDto officeDto)
        {
            return await _userService.CreateOffice(officeDto);
        }

        [Route("account/officeusers/{officeId}")]
        [HttpPost]
        public async Task<ActionResult<UserDto>> AddOfficeUser(UserDto userDto, string officeId) // in use
        {
            return await _userService.AddOfficeUser(userDto, officeId);
        }

        #endregion

        #region Role part

        [Route("account/roles/{officeId}")] // in use
        [HttpGet]
        public async Task<IList<RoleDto>> GetOfficeRoles(string officeId) 
        {
            return await _userService.GetOfficeRoles(officeId);
        }

        [Route("account/roles/create")]
        [HttpPost]
        public async Task<ActionResult<RoleDto>> CreateRole([FromBody] RoleDto roleDto)
        {
            return await _userService.CreateRole(roleDto);
        }

        [Route("account/roles/user/{officeId}/{userId}/{roleId}")]
        [HttpPost]
        public async Task<ActionResult<UserDto>> UpdateRoleUser(string officeId, string userId, string roleId)
        {
            return await _userService.UpdateRoleUser(officeId, userId, roleId);
        }

        #endregion

        #region EntityType part

        [Route("account/entitytypes/create")]
        [HttpPost]
        public async Task<ActionResult<EntityTypeDto>> CreateEntityType([FromBody] EntityTypeDto entityTypeDto)
        {
            return await _userService.CreateEntityType(entityTypeDto);
        }

        [Route("account/entitytypes")]
        [HttpGet]
        public async Task<IList<EntityTypeDto>> GetAllEntityTypes()
        {
            return await _userService.GetAllEntityTypes();
        }
        #endregion

        #region GroupEntityAccessPolicy

        [Route("account/grouppolicies/create")]
        [HttpPost]
        public async Task<ActionResult<GroupEntityAccessPolicyDto>> CreateGroupEntityAccessPolicy([FromBody] GroupEntityAccessPolicyDto groupEntityAccessPolicyDto)
        {
            return await _userService.CreateGroupEntityAccessPolicy(groupEntityAccessPolicyDto);
        }

        #endregion
    }
}
