using Newtonsoft.Json;

namespace IFoodAPI.Models
{
    public class Customer
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("uuid")]
        public string Uuid { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// CPF/CNPJ do cliente
        /// </summary>
        [JsonProperty("taxPayerIdentificationNumber")]
        public string TaxPayerIdentificationNumber { get; private set; }

        [JsonProperty("phone")]
        public string Phone { get; private set; }
        
        [JsonProperty("email")]
        public string Email { get; private set; }

        [JsonProperty("ordersCountOnRestaurant")]
        public int OrdersCountOnRestaurant { get; private set; }

        public Customer()
        {

        }

        public Customer(string id, string uuid, string name, string taxPayerIdentificationNumber, string phone, string email, int ordersCountOnRestaurant)
        {
            Id = id;
            Uuid = uuid;
            Name = name;
            TaxPayerIdentificationNumber = taxPayerIdentificationNumber;
            Phone = phone;
            Email = email;
            OrdersCountOnRestaurant = ordersCountOnRestaurant;
        }
    }
}
