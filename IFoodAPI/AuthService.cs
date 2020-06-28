using IFoodAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFoodAPI
{
    public static class AuthService
    {
        public static Token Token { get; private set; }

        public static async Task Authenticate(Credentials credentials)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "oauth/token");
            request.Headers.Add("ContentType", "multipart/form-data");
            request.Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("client_id", credentials.ClientId),
                new KeyValuePair<string, string>("client_secret", credentials.ClientSecret),
                new KeyValuePair<string, string>("username", credentials.Username),
                new KeyValuePair<string, string>("password", credentials.Password),
                new KeyValuePair<string, string>("grant_type", credentials.GrantType),
            });

            HttpResponseMessage response = await ApiService.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            Token = JsonConvert.DeserializeObject<Token>(content);
        }
    }
}
