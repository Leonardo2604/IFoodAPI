using IFoodAPI.Exceptions;
using IFoodAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IFoodAPI
{
    public static class EventService
    {
        private const string _baseUrl = "v1.0/events";
        /// <summary>
        /// Obtém todos os eventos ainda não recebidos. É necessario que o restaurante faça o polling a cada 30 seguntos para que se mantenha aberto no IFood
        /// <see href="https://developer.ifood.com.br/reference#eventspolling">Referencia</see>
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Event>> GetAll()
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}%3Apolling");
            request.Headers.Add("Authorization", AuthService.Token.FullToken);

            try
            {
                HttpResponseMessage response = await ApiService.SendAsync(request);
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Event>>(content);
            } 
            catch (RequestException ex) 
            {
                if (ex.Code == (int)HttpStatusCode.NotFound)
                {
                    return new List<Event>();
                }
                else
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Após o e-PDV receber os eventos de pedido via polling, é necessário que se faça o acknowledgement para o iFood saber que os eventos foram recebidos e o e-PDV não precisa mais receber esses eventos nas próximas requests de polling. A request de acknowledgment aceita uma lista de no máximo 2000 ids de eventos. Faça uma request de acknowledgment para cada request de polling com resultados.
        /// IMPORTANTE:
        /// Caso receba eventos que não usados pelo seu e-PDV, faça o acknowledgment desses eventos para que não fique recebendo-os a cada polling.
        /// Só é preciso fazer acknowledgment do evento uma única vez.
        /// No corpo da request, passe um array contendo apenas os ids dos eventos.
        /// <see href="https://developer.ifood.com.br/reference#eventsacknowledgment">Referencia</see>
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        public static async Task ConfirmEvents(List<Event> events)
        {
            if (AuthService.Token == null) 
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/acknowledgment");
            request.Headers.Add("Authorization", AuthService.Token.FullToken);
            request.Headers.Add("Cache-Control", "no-cache");

            List<object> parameters = new List<object> ();
            
            foreach (Event @event in events) 
            {
                parameters.Add(new { id = @event.Id });
            }

            string contentRequest = JsonConvert.SerializeObject(parameters);
            request.Content = new StringContent(contentRequest, Encoding.UTF8, "application/json");
            await ApiService.SendAsync(request);
        }
    }
}
