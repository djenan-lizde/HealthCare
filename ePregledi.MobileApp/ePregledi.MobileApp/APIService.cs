using ePregledi.Models;
using Flurl.Http;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ePregledi.MobileApp
{
    public class APIService
    {
        public static string Token { get; set; }
        public static int UserId { get; set; }
        public static string Role { get; set; }

        private readonly string _route;

#if DEBUG
        private readonly string _apiUrl = "http://localhost:57469/api";
#endif
#if RELEASE
        private string _apiUrl = "http://localhost:57469/api"; 
#endif

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search = null, string relativeRoute = null)
        {
            try
            {
                string url;
                if (string.IsNullOrEmpty(relativeRoute))
                {
                    url = $"{_apiUrl}/{_route}";
                }
                else
                {
                    url = $"{_apiUrl}/{_route}/{relativeRoute}";
                }
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Wrong username or password", "Try again");
                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Forbidden", "Try again");
                }
                throw;
            }

        }

        public async Task<T> GetById<T>(object id, string relativeRoute = null)
        {
            string url;
            if (string.IsNullOrEmpty(relativeRoute))
            {
                url = $"{_apiUrl}/{_route}/{id}";
            }
            else
            {
                url = $"{_apiUrl}/{_route}/{relativeRoute}/{id}";
            }

            return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object insert, string relativeRoute = null)
        {
            try
            {
                string url;
                if (string.IsNullOrEmpty(relativeRoute))
                {
                    url = $"{_apiUrl}/{_route}";
                }
                else
                {
                    url = $"{_apiUrl}/{_route}/{relativeRoute}";
                }
                return await url.WithOAuthBearerToken(Token).PostJsonAsync(insert).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "Try again");
                return default(T);
            }
        }

        public async Task<T> Update<T>(object insert, string Id, string relativeRoute = null)
        {
            try
            {
                string url;
                if (string.IsNullOrEmpty(relativeRoute))
                {
                    url = $"{_apiUrl}/{_route}/{Id}";
                }
                else
                {
                    url = $"{_apiUrl}/{_route}/{relativeRoute}";
                }

                return await url.WithOAuthBearerToken(Token).PutJsonAsync(insert).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
    }
}
