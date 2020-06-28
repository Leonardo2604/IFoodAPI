using Newtonsoft.Json;

namespace IFoodAPI.Models
{
    public class DeliveryMethod
    {
        /// <summary>
        /// indica o método de entrega. ( DEFAULT / ECONOMIC / PICKUP_AREA).
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        /// <summary>
        /// valor da entrega pago pelo cliente.
        /// </summary>
        [JsonProperty("value")]
        public float Value { get; private set; }

        /// <summary>
        /// tempo mínimo prometido ao cliente em minutos.
        /// </summary>
        [JsonProperty("minTime")]
        public int MinTime { get; private set; }

        /// <summary>
        /// tempo máximo prometido ao cliente em minutos.
        /// </summary>
        [JsonProperty("maxTime")]
        public int MaxTime { get; private set; }

        /// <summary>
        /// modo de entrega. Valores (DELIVERY / TAKEOUT / INDOOR).
        /// </summary>
        [JsonProperty("mode")]
        public string Mode { get; private set; }

        /// <summary>
        /// campo utilizado para restaurantes que tem operação de entrega híbrida, ou seja, na qual o pedido pode ser entregue pela IFOOD ou pelo comerciante. ( MERCHANT / IFOOD / NOT_APPLICABLE).
        /// </summary>
        [JsonProperty("deliveredBy")]
        public string DeliveredBy { get; set; }

        public DeliveryMethod()
        {

        }

        public DeliveryMethod(string id, float value, int minTime, int maxTime, string mode, string deliveredBy)
        {
            Id = id;
            Value = value;
            MinTime = minTime;
            MaxTime = maxTime;
            Mode = mode;
            DeliveredBy = deliveredBy;
        }
    }
}
