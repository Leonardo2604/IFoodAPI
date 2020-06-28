using Newtonsoft.Json;

namespace IFoodAPI.Models
{
    public class Merchant
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        
        [JsonProperty("shortId")]
        public string ShortId { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }
        
        [JsonProperty("phones")]
        public string[] Phones { get; private set; }

        [JsonProperty("address")]
        public Address Address { get; private set; }

        public Merchant()
        {

        }

        public Merchant(string id, string shortId, string name, string[] phones, Address address)
        {
            Id = id;
            ShortId = shortId;
            Name = name;
            Phones = phones;
            Address = address;
        }
    }
}
