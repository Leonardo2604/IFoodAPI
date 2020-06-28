using Newtonsoft.Json;

namespace IFoodAPI.Models
{
    public class OrderSubItem
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        /// <summary>
        /// ID do item do catálogo
        /// </summary>
        [JsonProperty("externalId")]
        public string ExternalId { get; private set; }

        /// <summary>
        /// Código PDV do item no portal
        /// </summary>
        [JsonProperty("externalCode")]
        public string ExternalCode { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("quantity")]
        public int Quantity { get; private set; }

        [JsonProperty("price")]
        public float Price { get; private set; }

        [JsonProperty("totalPrice")]
        public float TotalPrice { get; private set; }

        [JsonProperty("discount")]
        public float Discount { get; private set; }
        
        [JsonProperty("addition")]
        public float Addition { get; private set; }

        public OrderSubItem()
        {

        }

        public OrderSubItem(string id, string externalId, string externalCode, string name, int quantity, float price, float totalPrice, float discount, float addition)
        {
            Id = id;
            ExternalId = externalId;
            ExternalCode = externalCode;
            Name = name;
            Quantity = quantity;
            Price = price;
            TotalPrice = totalPrice;
            Discount = discount;
            Addition = addition;
        }
    }
}
