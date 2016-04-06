using Microsoft.Owin.Security;
using System;
using System.IdentityModel.Tokens;
using System.Text;
using Thinktecture.IdentityModel.Tokens;

namespace Delecs.NewMessagingService.Server.IISHosted.Providers
{
    /// <summary>
    /// JWT format
    /// </summary>
    class JwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        /// <summary>
        /// Token issuer
        /// </summary>
        private readonly string Issuer;

        /// <summary>
        /// Audience
        /// </summary>
        private readonly string Audience;

        /// <summary>
        /// JWT secret
        /// </summary>
        private readonly string Secret;

        public JwtFormat(string issuer, string audience, string secret)
        {
            // throw exception if issuer is empty
            if (string.IsNullOrEmpty(value: issuer)) { throw new ArgumentNullException(paramName: "issuer"); }

            // throw exception if audience is empty
            if (string.IsNullOrEmpty(value: audience)) { throw new ArgumentNullException(paramName: "audience"); }

            // throw exception if secret is empty
            if (string.IsNullOrEmpty(value: secret)) { throw new ArgumentNullException(paramName: "secret"); }

            // assign provided issuer
            Issuer = issuer;

            // assign audience
            Audience = audience;

            // assign secret
            Secret = secret;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null) { throw new ArgumentNullException("data"); }

            var keyByteArray = UTF8Encoding.UTF8.GetBytes(s: Secret);

            var signingKey = new HmacSigningCredentials(keyByteArray);

            var issued = data.Properties.IssuedUtc;

            var expires = data.Properties.ExpiresUtc;

            // create JWT token
            var token = new JwtSecurityToken(issuer: Issuer, audience: Audience, claims: data.Identity.Claims, notBefore: issued.Value.UtcDateTime, expires: expires.Value.UtcDateTime, signingCredentials: signingKey);

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);

            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}