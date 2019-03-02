using System;
using System.Net;

namespace ApplicationCore.Errors
{
    public class ServiceException : Exception
    {
        public ServiceException(object errors = null)
        {
            Code = HttpStatusCode.BadRequest;
            Errors = errors;
        }

        public object Errors { get; set; }

        public HttpStatusCode Code { get; }
    }
}