using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MDM.eGob.ADM.API.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("test")]
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            var obj = new { Status = "true", Mensaje = "ApiRest Funcionando!" };
            return Ok(obj);
            //return Ok("ApiRest Funcionando!");
        }
    }
}
