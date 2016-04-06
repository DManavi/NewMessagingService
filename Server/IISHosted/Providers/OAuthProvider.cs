using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Delecs.NewMessagingService.Server.IISHosted.Providers
{
    /// <summary>
    /// OAuth provider
    /// </summary>
    class OAuthProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// Validate client authentication
        /// </summary>
        /// <param name="context">OAuth validate client context</param>
        /// <returns></returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // set validated
            context.Validated();

            // return empty result
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //Dummy check here, you need to do your DB checks against memebrship system http://bit.ly/SPAAuthCode
            if (context.UserName != context.Password)
            {
                // set invalid grant
                context.SetError("invalid_grant", "The user name or password is incorrect");

                return Task.FromResult<object>(null);
            }

            var identity = new ClaimsIdentity("JWT");

            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

            identity.AddClaim(new Claim("sub", context.UserName));

            var ticket = new AuthenticationTicket(identity, null);

            context.Validated(ticket);

            return Task.FromResult<object>(null);
        }
    }
}