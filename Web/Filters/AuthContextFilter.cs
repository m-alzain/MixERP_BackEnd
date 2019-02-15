using ApplicationCore.Interfaces.Accounts;
using Contracts.Accounts;
using Contracts.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Filters
{
    public class AuthContextFilter : IActionFilter // IAuthorizationFilter // 
    {
        private readonly IUserService _userService;
        private readonly AuthContext _authContext;

        public AuthContextFilter(IUserService userService, AuthContext userContext)
        {
            _userService = userService;
            _authContext = userContext;
        }


        //public void OnAuthorization(AuthorizationFilterContext context)
        //{
        //    var sub = context.HttpContext.User.Claims.FirstOrDefault(c => "sub".Equals(c.Type));
        //    var request = context.ActionDescriptor.Parameters;
        //    if (sub is null)
        //    {
        //        context.Result = new ForbidResult();
        //    }
        //}

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // do something before the action executes
            var sub = context.HttpContext.User.Claims.FirstOrDefault(c => "sub".Equals(c.Type));
            var email = context.HttpContext.User.Claims.FirstOrDefault(c => "email".Equals(c.Type)).Value;
            context.ActionArguments.TryGetValue("tenantId", out object tenantId);
            context.ActionArguments.TryGetValue("officeId", out object officeId);
            context.HttpContext.Request.Headers.TryGetValue("User-Agent", out StringValues browser);
            var request = context.HttpContext.Request.Path;
            if (sub == null)
            {
                context.Result = new ForbidResult();
            }
            if (email == null)
            {               
                context.Result = new ForbidResult();
            }
            UserDto currentUser = null;
            TenantDto currentTenant = null;
            OfficeDto currentOffice = null;
            RoleDto currentRole = null;
            var user = _userService.GetUserByEmail(email).Result;
            if (user == null)
            {               
                currentUser = _userService.CreateInitialUser(new UserDto { Email = email, Name = email, LastSeenOn = DateTime.Now, LastBrowser = browser, LastIp = context.HttpContext.Connection.RemoteIpAddress.ToString()}).Result;
            }else
            {
                user.LastBrowser = browser;
                user.LastIp = context.HttpContext.Connection.RemoteIpAddress.ToString();
                user.LastSeenOn = DateTime.Now;
                currentUser = _userService.UpdateUser(user, user.Id.ToString()).Result;
            }
            if (tenantId != null)
            {
                currentTenant = _userService.GetTenant(tenantId.ToString()).Result;
            }
            if (officeId != null)
            {
                currentOffice = currentUser.Offices.First(o => o.Id == Guid.Parse(officeId.ToString()));
            }
            if (currentTenant == null && currentOffice != null  )
            {
                currentTenant = _userService.GetTenant(currentOffice.TenantId.ToString()).Result;
            }
            if (currentOffice != null)
            {
                currentRole = currentUser.Roles.First(r => r.OfficeId == currentOffice.Id);
            }

            _authContext.CurrentUser = currentUser;
            _authContext.CurrentTenant = currentTenant;
            _authContext.CurrentOffice = currentOffice;
            _authContext.CurrentRole = currentRole;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
        }
    }
}
