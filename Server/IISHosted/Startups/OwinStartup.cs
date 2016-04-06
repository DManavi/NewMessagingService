using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Delecs.NewMessagingService.Server.IISHosted.Startups.OwinStartup))]
namespace Delecs.NewMessagingService.Server.IISHosted.Startups
{
    /// <summary>
    /// OWIN startup class
    /// </summary>
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            // enable cross origin resource sharing
            app.UseCors(CorsOptions.AllowAll);

            // configure authentication
            app.ConfigureAuth();

            // configure SignalR
            app.ConfigureSignalR();

            // configure web-api
            app.ConfigureWebApi();
        }
    }
}
