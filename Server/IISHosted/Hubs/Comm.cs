using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Delecs.NewMessagingService.Server.IISHosted.Hubs
{
    /// <summary>
    /// Communication hub
    /// </summary>
    [Authorize]
    [HubName(hubName: "comm")]
    public class Comm : Hub
    {

    }
}