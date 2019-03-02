using ApplicationCore.Interfaces.Accounts;
using Contracts.Accounts;
using Contracts.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Web.Handlers
{// We can have similar handler for Tenants operations where there is no specific office or specific role
    public class OfficeEntityTypeAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, EntityTypeDto>
    {
        private readonly AuthContext _authContext;


        public OfficeEntityTypeAuthorizationHandler(AuthContext authContext)
        {
            _authContext = authContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,OperationAuthorizationRequirement requirement,EntityTypeDto resource)
        {
            
            if(_authContext.CurrentOffice != null && _authContext.CurrentRole != null)
            {
                if (_authContext.CurrentRole.IsAdministrator || (_authContext.CurrentRole.GroupEntityAccessPolicies.FirstOrDefault(p => p.EntityType.EntityName.Equals(resource.EntityName,StringComparison.OrdinalIgnoreCase) && (int)p.AccessType>= GetOperaionNumber(requirement.Name)) != null))
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }

        private int GetOperaionNumber(string name)
        {
            switch (name.ToLower())
            {
                case "read":
                    return 1;
                case "create":
                    return 2;
                case "edit":
                    return 3;
                case "delete":
                    return 4;
                case "createfilter":
                    return 5;
                case "deletefilter":
                    return 6;
                case "export":
                    return 7;
                case "exportdata":
                    return 8;
                case "importdata":
                    return 9;
                case "execute":
                    return 10;
                case "verify":
                    return 11;
                default:
                    return 1000; // just any number bigger than any accesstype           
            }
        }
    }

    #region snippet_OperationsClass
    public static class Operations
    {        
        public static OperationAuthorizationRequirement Read = new OperationAuthorizationRequirement { Name = nameof(Read) };
        public static OperationAuthorizationRequirement Create = new OperationAuthorizationRequirement { Name = nameof(Create) };
        public static OperationAuthorizationRequirement Edit = new OperationAuthorizationRequirement { Name = nameof(Edit) };
        public static OperationAuthorizationRequirement Delete = new OperationAuthorizationRequirement { Name = nameof(Delete) };
        public static OperationAuthorizationRequirement CreateFilter = new OperationAuthorizationRequirement { Name = nameof(CreateFilter) };
        public static OperationAuthorizationRequirement DeleteFilter = new OperationAuthorizationRequirement { Name = nameof(DeleteFilter) };
        public static OperationAuthorizationRequirement Export = new OperationAuthorizationRequirement { Name = nameof(Export) };
        public static OperationAuthorizationRequirement ExportData = new OperationAuthorizationRequirement { Name = nameof(ExportData) };
        public static OperationAuthorizationRequirement ImportData = new OperationAuthorizationRequirement { Name = nameof(ImportData) };
        public static OperationAuthorizationRequirement Execute = new OperationAuthorizationRequirement { Name = nameof(Execute) };
        public static OperationAuthorizationRequirement Verify = new OperationAuthorizationRequirement { Name = nameof(Verify) };
    }

    
    #endregion
}