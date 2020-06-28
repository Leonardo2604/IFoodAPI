using Newtonsoft.Json;
using System.Collections.Generic;

namespace IFoodAPI.Models
{
    public class OrderItem
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

        [JsonProperty("subItemsPrice")]
        public float SubItemsPrice { get; private set; }

        [JsonProperty("totalPrice")]
        public float TotalPrice { get; private set; }

        [JsonProperty("Discount")]
        public float Discount { get; private set; }

        [JsonProperty("addition")]
        public float Addition { get; private set; }
        
        [JsonProperty("subItems")]
        public List<OrderSubItem> SubItems { get; private set; }
        
        [JsonProperty("index")]
        public int Index { get; private set; }

        public OrderItem()
        {

        }

        public OrderItem(string id, string externalId, string externalCode, string name, int quantity, float price, float subItemsPrice, float totalPrice, float discount, float addition, List<OrderSubItem> subItems, int index)
        {
            Id = id;
            ExternalId = externalId;
            ExternalCode = externalCode;
            Name = name;
            Quantity = quantity;
            Price = price;
            SubItemsPrice = subItemsPrice;
            TotalPrice = totalPrice;
            Discount = discount;
            Addition = addition;
            SubItems = subItems;
            Index = index;
        }
    }
}
