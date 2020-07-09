using IFoodAPI.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IFoodAPI
{
    public static class OrderService
    {
        /// <summary>
        /// Geralmente, após o e-PDV receber um evento com o código 'PLACED', é necessário obter os detalhes do pedido.
        /// Neste cenário, o campo correlationId do evento refere-se à referência do pedido e deve ser fornecido a este endpoint.
        /// <see href="https://developer.ifood.com.br/reference#ordersreference">Referencia</see>
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public static async Task<Order> GetOrder(Event @event)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"v3.0/orders/{@event.CorrelationId}"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);

                using (HttpResponseMessage response = await ApiService.SendAsync(request))
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Order>(content);
                }
            }
        }

        /// <summary>
        /// Informa ao IFood que o pedido foi integrado pelo e-PDV.
        /// Integração significa que o e-PDV foi capaz de realizar o parse do pedido e integrar em seu sistema.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static async Task ChangeStatusToIntegrated(Order order)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"v1.0/orders/{order.Reference}/statuses/integration"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);
                
                (await ApiService.SendAsync(request)).Dispose();
            }
        }

        /// <summary>
        /// Informa ao IFood que o pedido foi confirmado pelo e-PDV.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static async Task ChangeStatusToConfirmed(Order order)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"v1.0/orders/{order.Reference}/statuses/confirmation"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);

                (await ApiService.SendAsync(request)).Dispose();
            }
        }

        /// <summary>
        /// Informa ao IFood que o pedido saiu para ser entregue ao cliente.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static async Task ChangeStatusToDispatched(Order order)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"v1.0/orders/{order.Reference}/statuses/dispatch"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);
                
                (await ApiService.SendAsync(request)).Dispose();
            }
        }

        /// <summary>
        /// Informa ao IFood que o pedido saiu para ser entregue ao cliente.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static async Task ChangeStatusToCancelled(Order order, ReasonCancelation reason)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"v3.0/orders/{order.Reference}/statuses/cancellationRequested"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);

                string contentRequest = JsonConvert.SerializeObject(reason);
                request.Content = new StringContent(contentRequest, Encoding.UTF8, "application/json");
                (await ApiService.SendAsync(request)).Dispose();
            }
        }

        /// <summary>
        /// Aceita a solicitação de cancelamento feita pelo cliente.
        /// Em algumas situações, o cliente pode solicitar o cancelamento de um pedido. Quando isso acontece, a loja recebe um evento "CANCELLATION_REQUESTED" e pode aceitar o cancelamento através desse endpoint.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static async Task ChangeStatusToCancellationAccepted(Order order)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"v2.0/orders/{order.Reference}/statuses/consumerCancellationAccepted"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);
                
                (await ApiService.SendAsync(request)).Dispose();
            }
        }

        /// <summary>
        /// Rejeita a solicitação de cancelamento feita pelo cliente.
        /// Em algumas situações, o cliente pode solicitar o cancelamento de um pedido. Quando isso acontece, a loja recebe um evento "CANCELLATION_REQUESTED" e pode negar o cancelamento através desse endpoint.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static async Task ChangeStatusToCancellationDenied(Order order)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"v2.0/orders/{order.Reference}/statuses/consumerCancellationDenied"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);

                (await ApiService.SendAsync(request)).Dispose();
            }
        }

        /// <summary>
        /// Informa ao IFood que o pedido está pronto para retirada.
        /// Esse endpoint gera um evento READY_TO_DELIVER.
        /// Para pedidos ToGo, o cliente será notificado no app informando que o pedido está pronto para ser retirado.Para pedidos com entrega IFood, logística será notificada para notificar o entregador.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static async Task ChangeStatusToReadyToDeliver(Order order)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"v2.0/orders/{order.Reference}/statuses/readyToDeliver"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                (await ApiService.SendAsync(request)).Dispose();
            }
        }

        /// <summary>
        /// Permite obter a posição do Entregador
        /// 
        /// Esse endpoint permite obter informações sobre o entregador e a sua posição e só retorna os dados do entregador quando a entrega é feita pelo iFood.
        /// 
        /// Deve ser utilizado somente depois que o evento ASSIGN_DRIVER é gerado e pode ser consultado de 30 em 30 segundos. Em caso de mal uso pode ser bloqueado pelas políticas de rate limit e throttling.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static async Task<Tracking> TrackDelivery(Order order)
        {
            if (AuthService.Token == null)
            {
                // TODO: throw new Exception("Primeiro realize a authenticação")
            }

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"v1.0/orders/{order.Reference}/tracking"))
            {
                request.Headers.Add("Authorization", AuthService.Token.FullToken);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                
                using (HttpResponseMessage response = await ApiService.SendAsync(request))
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Tracking>(content);
                }
            }
        }
    }
}
