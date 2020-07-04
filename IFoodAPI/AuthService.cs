using IFoodAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFoodAPI
{
    public static class AuthService
    {
        public static Token Token { get; private set; }

        public static async Task Authenticate()
        {
            if (IFoodAPIService.Config == null)
            {
                // TODO: throw new Exception("Configure primeiro o api")
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "oauth/token");
            request.Headers.Add("ContentType", "multipart/form-data");
            request.Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("client_id", IFoodAPIService.Config.ClientId),
                new KeyValuePair<string, string>("client_secret", IFoodAPIService.Config.ClientSecret),
                new KeyValuePair<string, string>("username", IFoodAPIService.Config.Username),
                new KeyValuePair<string, string>("password", IFoodAPIService.Config.Password),
                new KeyValuePair<string, string>("grant_type", IFoodAPIService.Config.GrantType),
            });

            HttpResponseMessage response = await ApiService.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            Token = JsonConvert.DeserializeObject<Token>(content);
        }
    }
}
