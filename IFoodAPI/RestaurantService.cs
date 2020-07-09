using IFoodAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFoodAPI
{
    public static class RestaurantService
    {
        private const string _baseUrl = "v1.0/merchants";

        /// <summary>
        /// Lista todas as indisponibilidades cadastradas para um merchant. Consulte as indisponibilidades e obtenha o id da indisponibilidade para removê-la utilizando o endpoint de DELETE.
        /// <see href="https://developer.ifood.com.br/reference#v10merchantsmerchant_uuidunavailabilities">Referencia</see>
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        public static async Task<List<Unavailability>> GetUnavailabilities()
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            if (IFoodAPIService.Config == null)
            {
                // TODO: throw new Exception("Configure primeiro o api")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/{IFoodAPIService.Config.MerchantId}/unavailabilities"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);

                using (HttpResponseMessage response = await ApiService.SendAsync(request))
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Unavailability>>(content);
                }
            }
        }

        /// <summary>
        /// Remove indisponibilidades cadastradas e permite reabrir o merchant na plataforma.
        /// <see href="https://developer.ifood.com.br/reference#merchantsmerchant_uuidunavailabilitiesunavailability_id">Referencia</see>
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="unavailability"></param>
        /// <returns></returns>
        public static async Task DeleteUnavailability(Unavailability unavailability)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            if (IFoodAPIService.Config == null)
            {
                // TODO: throw new Exception("Configure primeiro o api")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, $"{_baseUrl}/{IFoodAPIService.Config.MerchantId}/unavailabilities/{unavailability.Id}"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);
                
                (await ApiService.SendAsync(request)).Dispose();
            }
        }
    }
}
