using Newtonsoft.Json;

namespace IFoodAPI.Models
{
    public class Reference
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("externalCode")]
        public string ExternalCode { get; set; }
    }
}
