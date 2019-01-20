//using ApplicationCore.Interfaces.Forms;
//using ApplicationCore.Services.Forms;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Web.Controllers.Api
//{
//    public class FormApiController : BaseApiController
//    {
//        private IFormRepository _formRepository;
//        public FormApiController(IFormRepository formRepository)
//        {
//            _formRepository = formRepository;
//        }
//        [AcceptVerbs("GET", "HEAD")]
//        [Route("api/forms/{schemaName}/{tableName}/meta")]
//        public async Task< ActionResult <EntityView> > GetEntityViewAsync(string schemaName, string tableName)
//        {
//            //try
//            //{
//            //    var repository = new FormRepository(schemaName, tableName, this.AppUser.Tenant, this.AppUser.LoginId, this.AppUser.UserId);
//            //    return await repository.GetMetaAsync().ConfigureAwait(true);
//            //}
//            //catch (UnauthorizedException)
//            //{
//            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
//            //}
//            //catch (DataAccessException ex)
//            //{
//            //    throw new HttpResponseException
//            //        (
//            //        new HttpResponseMessage
//            //        {
//            //            Content = new StringContent(ex.Message),
//            //            StatusCode = HttpStatusCode.InternalServerError
//            //        });
//            //}
//            try
//            {
//                return await _formRepository.GetMetaAsync(schemaName, tableName, null, 1, 1);
//            }
//            catch (Exception e)
//            {
//                return BadRequest();
//            }
            
//        }
//    }
//}
