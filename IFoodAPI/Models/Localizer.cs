using Newtonsoft.Json;

namespace IFoodAPI.Models
{
    public class Localizer
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        public Localizer()
        {

        }

        public Localizer(string id)
        {
            Id = id;
        }
    }
}
