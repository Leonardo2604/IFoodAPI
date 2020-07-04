using Newtonsoft.Json;
using System.Collections.Generic;

namespace IFoodAPI.Models
{
    public class Category
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("merchantID")]
        public string MerchantID { get; set; }

        [JsonProperty("externalCode")]
        public string ExternalCode { get; set; }

        [JsonProperty("availability")]
        public string Availability { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("template")]
        public string Template { get; private set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("skus")]
        public List<Sku> Skus { get; set; }

        public Category(string name, string description, string externalCode, string availability, int order)
        {
            ExternalCode = externalCode;
            Availability = availability;
            Name = name;
            Order = order;
            Template = "PADRAO";
            Description = description;
        }
    }
}
