using IFoodAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IFoodAPI
{
    public static class SurveyService
    {
        /// <summary>
        /// Retrieve on hold reviews in a period of 7 days
        /// <see href="https://developer.ifood.com.br/reference#surveyapiv1reviews">Referencia</see>
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Review>> GetReviews()
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            if (IFoodAPIService.Config == null)
            {
                // TODO: throw new Exception("Configure primeiro o api")
            }

            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            query["status"] = "ON_HOLD";
            query["merchant_ids[0]"] = IFoodAPIService.Config.MerchantId.ToString();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"v1.0/reviews?{query}");
            request.Headers.Add("Authorization", AuthService.Token.FullToken);

            HttpResponseMessage response =  await ApiService.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Review>>(content);
        }

        /// <summary>
        /// Insert a comment answer
        /// <see href="https://developer.ifood.com.br/reference#surveyapiv1reviewsreview_idanswers">Referencia</see>
        /// </summary>
        /// <param name="review"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static async Task Answer(Review review, string content)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            if (IFoodAPIService.Config == null)
            {
                // TODO: throw new Exception("Configure primeiro o api")
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"survey/api/v1/reviews/{review.Id}/answers");
            request.Headers.Add("Authorization", AuthService.Token.FullToken);

            object data = new { content };

            string requestContent = JsonConvert.SerializeObject(data);
            request.Content = new StringContent(requestContent, Encoding.UTF8, "application/json");
            await ApiService.SendAsync(request);
        }
    }
}
