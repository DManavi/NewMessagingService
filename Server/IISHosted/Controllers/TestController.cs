using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Delecs.NewMessagingService.Server.IISHosted.Controllers
{
    /// <summary>
    /// Test controller
    /// </summary>
    [RoutePrefix(prefix: "test")]
    public class TestController : ApiController
    {
        /// <summary>
        /// Unauthorized request
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route(template: "unauthorized")]
        public async Task<IHttpActionResult> Unauthorized()
        {
            // return current date/time of the server
            return Ok(content: DateTime.Now);
        }

        /// <summary>
        /// Authorized request test
        /// </summary>
        /// <returns>Return username & current date of the server</returns>
        [Authorize]
        [HttpGet]
        [Route(template: "authorized")]
        public async Task<IHttpActionResult> Authorized()
        {
            return Ok(content: string.Format("{0} at {1}", User.Identity.Name, DateTime.Now.ToString()));
        }
    }
}
