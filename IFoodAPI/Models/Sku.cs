using Newtonsoft.Json;
using System.Collections.Generic;

namespace IFoodAPI.Models
{
    public class Sku
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("availability")]
        public string Availability { get; set; }

        [JsonProperty("schedules")]
        public List<Schedule> Schedules { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("categories")]
        public List<Reference> Category { get; set; }

        [JsonProperty("sequence")]
        public int Sequence { get; set; }
    }
}
