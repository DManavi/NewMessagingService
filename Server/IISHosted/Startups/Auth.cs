using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Text;

namespace Delecs.NewMessagingService.Server.IISHosted.Startups
{
    /// <summary>
    /// Authentication config
    /// </summary>
    static class Auth
    {
        /// <summary>
        /// Configure authentication
        /// </summary>
        /// <param name="app">Application builder instance</param>
        public static void ConfigureAuth(this IAppBuilder app)
        {
            // create oauth server options
            var OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = Globals.IsDebugMode,
                TokenEndpointPath = new PathString("/account/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(Globals.TokenExpires),
                Provider = new Providers.OAuthProvider(),
                AccessTokenFormat = new Providers.JwtFormat(issuer: Globals.TokenIssuer, audience: Globals.TokenAudience, secret: Globals.TokenSecret)
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { Globals.TokenAudience },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer: Globals.TokenIssuer, key: Encoding.UTF8.GetBytes( Globals.TokenSecret))
                    }
                });
        }
    }
}
