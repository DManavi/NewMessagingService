using System.Web.Http;

namespace Delecs.NewMessagingService.Server.IISHosted.Controllers
{
    /// <summary>
    /// Account controller
    /// </summary>
    [Authorize]
    [RoutePrefix(prefix: "account")]
    public class AccountController : ApiController
    {
    }
}
