using Newtonsoft.Json;

namespace IFoodAPI.Models
{
    public class Coordinates
    {
        [JsonProperty("latitude")]
        public float Latitude { get; private set; }

        [JsonProperty("longitude")]
        public float Longitude { get; private set; }

        public Coordinates()
        {

        }

        public Coordinates(float latitude, float longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
