using Newtonsoft.Json;

namespace IFoodAPI.Models
{
    public class ComplementOption
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("externalCode")]
        public string ExternalCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("availability")]
        public string Availability { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("sequence")]
        public int Sequence { get; set; }
    }
}
