using Newtonsoft.Json;

namespace IFoodAPI.Models
{
    public class SponsorshipValues
    {
        [JsonProperty("IFOOD")]
        public float Ifood { get; private set; }

        [JsonProperty("MERCHANT")]
        public float Merchant { get; private set; }

        public SponsorshipValues()
        {

        }

        public SponsorshipValues(float ifood, float merchant)
        {
            Ifood = ifood;
            Merchant = merchant;
        }
    }
}
