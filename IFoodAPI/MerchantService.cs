using IFoodAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFoodAPI
{
    public static class MerchantService
    {
        public static async Task<List<Merchant>> GetMerchants()
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "v1.0/merchants"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);

                using (HttpResponseMessage response = await ApiService.SendAsync(request))
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Merchant>>(content);
                }
            }
        }
    }
}
