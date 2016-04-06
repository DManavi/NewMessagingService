
using System.Configuration;

namespace Delecs.NewMessagingService.Server.IISHosted
{
    /// <summary>
    /// Globals
    /// </summary>
    static class Globals
    {
        /// <summary>
        /// Is debug mode or not
        /// </summary>
        public static bool IsDebugMode
        {
            get
            {
                // create output variable
                var output = false;

                // try parse application settings
                bool.TryParse(value: ConfigurationManager.AppSettings["DEBUG-MODE"], result: out output);

                // return output to caller
                return output;
            }
        }

        /// <summary>
        /// Token issuer
        /// </summary>
        public static string TokenIssuer
        {
            get
            {
                return ConfigurationManager.AppSettings["TOKEN-ISSUER"];
            }
        }

        /// <summary>
        /// Token audience
        /// </summary>
        public static string TokenAudience
        {
            get
            {
                return ConfigurationManager.AppSettings["TOKEN-AUDIENCE"];
            }
        }

        /// <summary>
        /// Token secret
        /// </summary>
        public static string TokenSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["TOKEN-SECRET"];
            }
        }

        /// <summary>
        /// Token expires
        /// </summary>
        public static int TokenExpires
        {
            get
            {
                // create output variable
                var output = (int)15;

                // try parse token expiration from web.config
                int.TryParse(s: ConfigurationManager.AppSettings["TOKEN-EXPIRE-MINUTES"], result: out output);

                // return output to caller
                return output;
            }
        }
    }
}