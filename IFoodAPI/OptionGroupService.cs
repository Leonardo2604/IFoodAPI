﻿using IFoodAPI.Models;
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
    }
}