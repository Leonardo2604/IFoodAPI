using IFoodAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IFoodAPI
{
    public static class SkuService
    {
        public static async Task<List<OptionGroup>> GetComplements(Sku sku)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            if (IFoodAPIService.Config == null)
            {
                // TODO: throw new Exception("Configure primeiro o api")
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"v1.0/merchants/{IFoodAPIService.Config.MerchantId}/skus/{sku.Id}/option_groups");
            request.Headers.Add("Authorization", AuthService.Token.FullToken);
            HttpResponseMessage response = await ApiService.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<OptionGroup>>(content);
        }

        public static async Task Create(Sku sku)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            if (IFoodAPIService.Config == null)
            {
                // TODO: throw new Exception("Configure primeiro o api")
            }

            dynamic data = new ExpandoObject();
            data.merchantId = IFoodAPIService.Config.MerchantId;
            data.externalCode = sku.ExternalCode;
            data.availability = sku.Availability;
            data.name = sku.Name;
            
            if (!string.IsNullOrEmpty(sku.Ean))
            {
                data.ean = sku.Ean;
            }

            data.description = sku.Description;
            data.order = sku.Sequence;
            data.price = new 
            {
                value = sku.Price.Value,
                originalValue = sku.Price.OriginalValue,
                promotional = sku.Price.Promotional
            };

            if (sku.Schedules != null && sku.Schedules.Count > 0) 
            {
                data.schedules = new List<object>();

                foreach (Schedule schedule in sku.Schedules)
                {
                    data.schedules.Add(new { dayOfWeek = schedule.DayOfWeek });
                }
            }

            if (sku.SellingOption != null)
            {
                data.sellingOption = sku.SellingOption;
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"v1.0/skus");
            request.Headers.Add("Authorization", AuthService.Token.FullToken);

            string requestContent = JsonConvert.SerializeObject(data);

            MultipartFormDataContent content = new MultipartFormDataContent
            {
                { new StringContent(requestContent, Encoding.UTF8, "application/json"), "\"sku\"" }
            };

            request.Content = content;

            await ApiService.SendAsync(request);
        }

        public static async Task LinkOptionGroup(Sku sku, OptionGroup optionGroup)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            if (IFoodAPIService.Config == null)
            {
                // TODO: throw new Exception("Configure primeiro o api")
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"v1.0/skus/{sku.ExternalCode}/option-groups:link");
            request.Headers.Add("Authorization", AuthService.Token.FullToken);

            object data = new
            {
                externalCode = optionGroup.ExternalCode,
                merchantId = IFoodAPIService.Config.MerchantId,
                order = sku.Sequence,
                maxQuantity = optionGroup.MaxQuantity,
                minQuantity = optionGroup.MinQuantity
            };

            string contentRequest = JsonConvert.SerializeObject(data);
            request.Content = new StringContent(contentRequest, Encoding.UTF8, "application/json");
            await ApiService.SendAsync(request);
        }

        public static async Task UpdatePrice(Sku sku)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            if (IFoodAPIService.Config == null)
            {
                // TODO: throw new Exception("Configure primeiro o api")
            }

            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), $"v1.0/skus/{sku.ExternalCode}/prices");
            request.Headers.Add("Authorization", AuthService.Token.FullToken);

            object data = new 
            {
                merchantIds = new List<int> { IFoodAPIService.Config.MerchantId },
                isPromotional = sku.Price.Promotional,
                originalPrice = sku.Price.OriginalValue,
                price = sku.Price.Value
            };

            string contentRequest = JsonConvert.SerializeObject(data);
            request.Content = new StringContent(contentRequest, Encoding.UTF8, "application/json");
            await ApiService.SendAsync(request);
        }
    }
}
