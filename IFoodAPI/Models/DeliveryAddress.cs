using Newtonsoft.Json;

namespace IFoodAPI.Models
{
    public class DeliveryAddress : Address
    {
        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; private set; }

        public DeliveryAddress(
            string formattedAddress,
            string country,
            string state,
            string city,
            string neighborhood,
            string streetName,
            string streetNumber,
            string postalCode,
            string reference,
            string complement,
            Coordinates coordinates) : base(
                formattedAddress,
                country,
                state,
                city,
                neighborhood,
                streetName,
                streetNumber,
                postalCode,
                reference,
                complement)
        {
            Coordinates = coordinates;
        }
    }
}
