using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizletNet
{
    using HTTP;
    using HTTP.Models;

    public class OAuth
    {
        public static bool IsAuthorized
        {
            get
            {
                return AccessToken != null;
            }
        }

        internal static string AccessToken { get; private set; }
        internal static string BasicAuthString { get; private set; }

        internal static void Initialize()
        {
            AccessToken = (string)LocalStorage.Get("AccessToken");
        }

        public static void SetAuthData(string clientId, string clientSecret)
        {
            BasicAuthString = Convert.ToBase64String(
                Encoding.UTF8.GetBytes(clientId + ":" + clientSecret));
        }

        public static string GetOAuthUri(string clientId, string redirectUri)
        {
            redirectUri = Uri.EscapeUriString(redirectUri);

            return $"https://quizlet.com/authorize?response_type=code&client_id={clientId}&scope=read&state=QuizletNetOAuth&redirect_uri={redirectUri}";
        }

        public static async Task<bool> RequestAuthorize(string code, string redirectUri)
        {
            try
            {
                var response = await RestCall.PostAsync<OAuthTokenResponse>(
                    Quizlet.Endpoint + "/oauth/token",
                    new Dictionary<string, object>() {
                        {"code", code},
                        {"grant_type", "authorization_code"},
                        {"redirect_uri", redirectUri}
                    });

                // TODO : REFRESH
                AccessToken = response.access_token;
                LocalStorage.Set("AccessToken", AccessToken);
            }
            catch(Exception e)
            {
                AccessToken = null;
            }

            return IsAuthorized;
        }
    }
}
