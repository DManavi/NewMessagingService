using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;

namespace Delecs.NewMessagingService.Server.IISHosted.Startups
{
    /// <summary>
    /// Web API configuration
    /// </summary>
    static class WebApi
    {
        /// <summary>
        /// Configure WebAPI
        /// </summary>
        /// <param name="app">Application builder instance</param>
        public static void ConfigureWebApi(this IAppBuilder app)
        {
            // create new HTTP configuration
            var config = new HttpConfiguration();

            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();

            // add default authentication filter
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            // enable detailed error if application is in debug mode
            config.IncludeErrorDetailPolicy = Globals.IsDebugMode ? IncludeErrorDetailPolicy.Always : IncludeErrorDetailPolicy.Never;

            // map API route
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // enable Web API
            app.UseWebApi(configuration: config);
        }
    }
}