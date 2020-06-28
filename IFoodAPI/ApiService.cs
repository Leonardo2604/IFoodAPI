using System;
using System.Net.Http;
using System.Threading.Tasks;
using IFoodAPI.Exceptions;

namespace IFoodAPI
{
    static class ApiService
    {
        private static HttpClient _httpClient;
        private const string _baseUrl = "https://pos-api.ifood.com.br/";

        private static HttpClient GetInstance() 
        {
            if (_httpClient == null)
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(_baseUrl)
                };
                _httpClient = client;
            }

            return _httpClient;
        }

        public static async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            HttpClient client = GetInstance();
            HttpResponseMessage response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new RequestException("Falha na requisição", (int)response.StatusCode);
            }

            return response;
        }
    }
}
