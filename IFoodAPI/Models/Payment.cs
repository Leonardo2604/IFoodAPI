using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IFoodAPI.Models
{
    public class Payment
    {
        /// <summary>
        /// Nome da forma de pagamento
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Codigo da forma de pagamento
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; private set; }

        /// <summary>
        /// Valor pago na forma
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; private set; }

        /// <summary>
        /// Pedido pago ('true' ou 'false')
        /// </summary>
        [JsonProperty("prepaid")]
        public bool Prepaid { get; private set; }

        [JsonProperty("transaction")]
        public string Transaction { get; private set; }

        /// <summary>
        /// Bandeira
        /// </summary>
        [JsonProperty("issuer")]
        public string Issuer { get; private set; }

        /// <summary>
        /// Troco 
        /// </summary>
        [JsonProperty("changeFor")]
        public float ChangeFor { get; private set; }

        [JsonProperty("collector")]
        public string Collector { get; private set; }

        [JsonProperty("authorizationCode")]
        public string AuthorizationCode { get; private set; }

        public Payment()
        {
        }

        public Payment(string name, string code, string value, bool prepaid, string issuer, float changeFor, string collector, string transaction, string authorizationCode)
        {
            Name = name;
            Code = code;
            Value = value;
            Prepaid = prepaid;
            Issuer = issuer;
            ChangeFor = changeFor;
            Collector = collector;
            Transaction = transaction;
            AuthorizationCode = authorizationCode;
        }
    }
}
