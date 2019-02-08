using ApplicationCore.Interfaces.Accounts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Filters
{
    public class UserContextFilter : IActionFilter // IAuthorizationFilter // 
    {
        private readonly IUserService _userService;

        public UserContextFilter(IUserService userService)
        {
            _userService = userService;
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
            context.ActionArguments.TryGetValue("tenantId", out object tenantId);
            context.ActionArguments.TryGetValue("officeId", out object officeId);
            var request = context.HttpContext.Request.Path;
            if (sub is null)
            {
                context.Result = new ForbidResult();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
        }
    }
}
