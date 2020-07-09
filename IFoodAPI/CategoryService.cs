using IFoodAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IFoodAPI
{
    public static class CategoryService
    {
        /// <summary>
        /// Lista todas as categorias do cardápio de um restaurante.
        /// <see href="https://developer.ifood.com.br/reference#categories">Referencia</see>
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        public static async Task<List<Category>> GetAll()
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            if (IFoodAPIService.Config == null)
            {
                // TODO: throw new Exception("Configure primeiro o api")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"v1.0/merchants/{IFoodAPIService.Config.MerchantId}/menus/categories"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);

                using (HttpResponseMessage response = await ApiService.SendAsync(request))
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Category>>(content);
                }
            }
        }

        /// <summary>
        /// Lista todos os itens de uma categoria
        /// <see href="https://developer.ifood.com.br/reference#categories2">Referencia</see>
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static async Task<Category> GetWithSkus(Category category)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            if (IFoodAPIService.Config == null)
            {
                // TODO: throw new Exception("Configure primeiro o api")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"v1.0/merchants/{IFoodAPIService.Config.MerchantId}/menus/categories/{category.Id}"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);

                using (HttpResponseMessage response = await ApiService.SendAsync(request))
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Category>(content);
                }
            }
        }

        /// <summary>
        /// Cria uma categoria dentro do cardápio
        /// <see href="https://developer.ifood.com.br/reference#cadastrar-categoria">Referencia</see>
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static async Task Create(Category category)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "v1.0/categories"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);

                object data = new
                {
                    merchantId = IFoodAPIService.Config.MerchantId,
                    availability = category.Availability,
                    name = category.Name,
                    order = category.Order,
                    template = category.Template,
                    externalCode = category.ExternalCode
                };

                string contentRequest = JsonConvert.SerializeObject(data);
                request.Content = new StringContent(contentRequest, Encoding.UTF8, "application/json");
                (await ApiService.SendAsync(request)).Dispose();
            }
        }

        /// <summary>
        /// Atualiza uma categoria existente
        /// <see href="https://developer.ifood.com.br/reference#categories-1">Referencia</see>
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static async Task Update(Category category)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, "v1.0/categories"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);

                object data = new
                {
                    merchantId = IFoodAPIService.Config.MerchantId,
                    availability = category.Availability,
                    name = category.Name,
                    order = category.Order,
                    template = category.Template,
                    externalCode = category.ExternalCode
                };
                string contentRequest = JsonConvert.SerializeObject(data);
                request.Content = new StringContent(contentRequest, Encoding.UTF8, "application/json");
                (await ApiService.SendAsync(request)).Dispose();
            }
        }

        /// <summary>
        /// Deletar uma categoria dentro do cardápio
        /// <see href="https://developer.ifood.com.br/reference#deletar-categoria">Referencia</see>
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static async Task Delete(Category category)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, "v1.0/categories"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);

                object data = new
                {
                    merchantId = IFoodAPIService.Config.MerchantId,
                    availability = "DELETED",
                    name = category.Name,
                    order = category.Order,
                    template = category.Template,
                    externalCode = category.ExternalCode,
                };
                string contentRequest = JsonConvert.SerializeObject(data);
                request.Content = new StringContent(contentRequest, Encoding.UTF8, "application/json");
                (await ApiService.SendAsync(request)).Dispose();
            }
        }

        /// <summary>
        /// Linka Categoria Pai ao item pai
        /// <see href="https://developer.ifood.com.br/reference#categoriesexternal_codeskuslink">Referencia</see>
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        public static async Task LinkSku(Category category, Sku sku)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            if (IFoodAPIService.Config == null)
            {
                // TODO: throw new Exception("Configure primeiro o api")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"v1.0/categories/{category.ExternalCode}/skus:link"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);

                object data = new
                {
                    externalCode = sku.ExternalCode,
                    merchantId = IFoodAPIService.Config.MerchantId,
                    order = sku.Sequence
                };

                string contentRequest = JsonConvert.SerializeObject(data);
                request.Content = new StringContent(contentRequest, Encoding.UTF8, "application/json");
                (await ApiService.SendAsync(request)).Dispose();
            }
        }

        /// <summary>
        /// Desfazer link da categoria pai ao item pai (efeito cascata)
        /// <see href="https://developer.ifood.com.br/reference#categoriescategory_external_codeskusunlink">Referencia</see>
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        public static async Task UnlinkSku(Category category, Sku sku)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            if (IFoodAPIService.Config == null)
            {
                // TODO: throw new Exception("Configure primeiro o api")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"v1.0/categories/{category.ExternalCode}/skus:unlink"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);

                object data = new
                {
                    externalCode = sku.ExternalCode,
                    merchantId = IFoodAPIService.Config.MerchantId,
                    order = sku.Sequence
                };

                string contentRequest = JsonConvert.SerializeObject(data);
                request.Content = new StringContent(contentRequest, Encoding.UTF8, "application/json");
                (await ApiService.SendAsync(request)).Dispose();
            }
        }
    }
}
