using ApplicationCore.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Web.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        //private readonly ILogger<ErrorHandlingMiddleware> _logger;
        //private readonly IStringLocalizer<ErrorHandlingMiddleware> _localizer;

        public ErrorHandlingMiddleware(
            RequestDelegate next
            //IStringLocalizer<ErrorHandlingMiddleware> localizer
            //ILogger<ErrorHandlingMiddleware> logger
            )
        {
            this.next = next;
            //this._logger = logger;
            //this._localizer = localizer;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(
            HttpContext context,
            Exception exception
            //ILogger<ErrorHandlingMiddleware> logger,
            //IStringLocalizer<ErrorHandlingMiddleware> localizer
            )
        {
            object errors = null;

            switch (exception)
            {
                case ServiceException re:
                    errors = re.Errors;
                    context.Response.StatusCode = (int)re.Code;
                    break;
                case UnauthorizedAccessException unauthorized:
                    errors = unauthorized.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    break;
                case Exception e:
                    errors = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";

            var result = JsonConvert.SerializeObject(new
            {
                errors
            });

            await context.Response.WriteAsync(result);
        }
    }
}
