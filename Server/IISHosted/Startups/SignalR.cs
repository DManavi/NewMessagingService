using Microsoft.AspNet.SignalR;
using Owin;

namespace Delecs.NewMessagingService.Server.IISHosted.Startups
{
    /// <summary>
    /// SignalR configuration
    /// </summary>
    static class SignalR
    {
        /// <summary>
        /// Configure signalR
        /// </summary>
        /// <param name="app">Application builder instance</param>
        public static void ConfigureSignalR(this IAppBuilder app)
        {
            // create new hub configuration
            var config = new HubConfiguration();

            // enable detailed error in debug mode
            config.EnableDetailedErrors = Globals.IsDebugMode;

            // enable JS proxies in debug mode
            config.EnableJavaScriptProxies = config.EnableDetailedErrors;

            // enable signalR
            app.MapSignalR(configuration: config);
        }
    }
}