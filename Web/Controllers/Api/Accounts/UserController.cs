using ApplicationCore.Interfaces.Accounts;
using Contracts.Accounts;
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

        [Route("account/tenants/get")]
        [HttpGet]
        public async Task<IList<TenantDto>> GetAllTenants()
        {
            return await _userService.GetAllTenants();
        }

        [Route("account/tenants/get/{tenantId}")]
        [HttpGet]
        public async Task<TenantDto> GetTenant(string tenantId)
        {
            return await _userService.GetTenant(tenantId);
        }

        [Route("account/tenant/offices/get/{tenantId}")]
        [HttpGet]
        public async Task<IList<OfficeDto>> GetTenantOffices(string tenantId)
        {
            return await _userService.GetTenantOffices(tenantId);
        }

        [Route("account/user/tenants/get/{userId}")]
        [HttpGet]
        public async Task<IList<TenantDto>> GetUserTenants(string userId)
        {
            return await _userService.GetUserTenants(userId);
        }

        [Route("account/tenants/create")]
        [HttpPost]
        public async Task<ActionResult<TenantDto>> CreateTenant([FromBody] TenantDto tenantDto)
        {
            return await _userService.CreateTenant(tenantDto);
        }

        [Route("account/offices/get")]
        [HttpGet]
        public async Task<IList<OfficeDto>> GetAllOffices()
        {
            return await _userService.GetAllOffices();
        }

        [Route("account/user/offices/get/{userId}")]
        [HttpGet]
        public async Task<IList<OfficeDto>> GetUserOffices(string userId)
        {
            return await _userService.GetUserOffices(userId);
        }

        [Route("account/users/get")]
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

        [Route("account/office/users/get/{officeId}")]
        [HttpGet]
        public async Task<IList<UserDto>> GetOfficeUsers(string officeId)
        {
            return await _userService.GetOfficeUsers(officeId);
        }

        [Route("account/users/create/{officeId}")]
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto userDto, string officeId)
        {
            return await _userService.CreateUser(userDto, officeId);
        }

        [Route("account/users/add/{userId}/{officeId}")]
        [HttpPost]
        public async Task<ActionResult<UserDto>> AddUser(string userId, string officeId)
        {
            return await _userService.AddUser(userId, officeId);
        }

        [Route("account/users/delete/{userId}")]
        [HttpDelete]
        public async Task<ActionResult<string>> DeleteUser(string userId)
        {
            return await _userService.DeleteUser(userId);
        }
    }
}
