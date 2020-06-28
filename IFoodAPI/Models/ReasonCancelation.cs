using Newtonsoft.Json;

namespace IFoodAPI.Models
{
    public class ReasonCancelation
    {
        [JsonProperty("cancellationCode")]
        public int CancellationCode { get; private set; }

        [JsonProperty("details")]
        public string Details { get; private set; }

        public ReasonCancelation()
        {

        }

        public ReasonCancelation(int cancellationCode, string details)
        {
            CancellationCode = cancellationCode;
            Details = details;
        }
    }
}
