using IFoodAPI.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IFoodAPI
{
    public static class OptionGroupService
    {
        public static async Task Create(OptionGroup optionGroup)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            if (IFoodAPIService.Config == null)
            {
                // TODO: throw new Exception("Configure primeiro o api")
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "v1.0/option-groups");
            request.Headers.Add("Authorization", AuthService.Token.FullToken);

            object data = new 
            {
                merchantId = IFoodAPIService.Config.MerchantId,
                externalCode = optionGroup.ExternalCode,
                maxQuantity = optionGroup.MaxQuantity,
                minQuantity = optionGroup.MinQuantity,
                name = optionGroup.Name,
                sequence = optionGroup.Sequence
            };

            string requestContent = JsonConvert.SerializeObject(data);
            request.Content = new StringContent(requestContent, Encoding.UTF8, "application/json");

            await ApiService.SendAsync(request);
        }

        public static async Task Update(OptionGroup optionGroup)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            if (IFoodAPIService.Config == null)
            {
                // TODO: throw new Exception("Configure primeiro o api")
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, $"v1.0/option-groups/{optionGroup.ExternalCode}");
            request.Headers.Add("Authorization", AuthService.Token.FullToken);

            object data = new
            {
                merchantId = IFoodAPIService.Config.MerchantId,
                maxQuantity = optionGroup.MaxQuantity,
                minQuantity = optionGroup.MinQuantity,
                name = optionGroup.Name,
                sequence = optionGroup.Sequence
            };

            string requestContent = JsonConvert.SerializeObject(data);
            request.Content = new StringContent(requestContent, Encoding.UTF8, "application/json");

            await ApiService.SendAsync(request);
        }

        /// <summary>
        /// Linka o complemento ao option-group
        /// <see href="https://developer.ifood.com.br/reference#option-groupsexternal_codeskuslink">Referencia</see>
        /// </summary>
        /// <param name="optionGroup"></param>
        /// <param name="sku"></param>
        /// <returns></returns>
        public static async Task LinkSku(OptionGroup optionGroup, Sku sku)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            if (IFoodAPIService.Config == null)
            {
                // TODO: throw new Exception("Configure primeiro o api")
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"v1.0/option-groups/{optionGroup.ExternalCode}/skus:link");
            request.Headers.Add("Authorization", AuthService.Token.FullToken);

            object data = new
            {
                externalCode = sku.ExternalCode,
                merchantId = IFoodAPIService.Config.MerchantId,
                order = sku.Sequence
            };

            string contentRequest = JsonConvert.SerializeObject(data);
            request.Content = new StringContent(contentRequest, Encoding.UTF8, "application/json");
            await ApiService.SendAsync(request);
        }
    }
}
