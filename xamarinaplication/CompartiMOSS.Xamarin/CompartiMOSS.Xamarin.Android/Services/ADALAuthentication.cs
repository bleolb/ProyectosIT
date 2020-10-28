using CompartiMOSS.Xamarin.Models;
using CompartiMOSS.Xamarin.Services.Authentication;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Plugin.CurrentActivity;
using System;
using System.Linq;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(CompartiMOSS.Xamarin.Droid.Services.ADALAuthenticator))]
namespace CompartiMOSS.Xamarin.Droid.Services
{
    public class ADALAuthenticator : IADALAuthenticator
    {
        private const string TenantUrl = "https://login.microsoftonline.com/common";
        public static string ADClientId = "f9ee42d8-c538-4037-bd5e-241037cb72bb";
        public static string tenant = "6f385f7a-a2ea-4f16-90fc-ce00b0da6f1c";
        public static Uri returnUriId = new Uri("http://cgweb.xamarin.net");
        public static string WebApiADClientId = "7d34eca0-8c7d-4f12-a8c3-83f96083294a";

        public async Task<ADToken> AuthenticationAsync()
        {
            try
            {
                var platformParams = new PlatformParameters(CrossCurrentActivity.Current.Activity);
                var authContext = new AuthenticationContext(TenantUrl);

                if (authContext.TokenCache.ReadItems().Any())
                {
                    authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().FirstOrDefault().Authority);
                }

                var authResult = await authContext.AcquireTokenAsync(WebApiADClientId, ADClientId, returnUriId, platformParams);

                return new ADToken()
                {
                    AccessToken = authResult.AccessToken,
                    TokenType = authResult.AccessTokenType,
                    Expires = authResult.ExpiresOn.Ticks,
                    UserName = authResult.UserInfo.DisplayableId
                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
