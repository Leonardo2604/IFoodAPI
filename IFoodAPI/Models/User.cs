using Newtonsoft.Json;

namespace IFoodAPI.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        public User(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
