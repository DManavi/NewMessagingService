using System.Web.Http;

namespace Delecs.NewMessagingService.Server.IISHosted.Controllers
{
    /// <summary>
    /// Discussion controller
    /// </summary>
    [Authorize]
    [RoutePrefix("discussion")]
    public class DiscussionController : ApiController
    {
    }
}
