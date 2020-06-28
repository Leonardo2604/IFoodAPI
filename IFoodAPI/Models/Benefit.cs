using Newtonsoft.Json;

namespace IFoodAPI.Models
{
    public class Benefit
    {
        /// <summary>
        /// Valor do desconto oferecido
        /// </summary>
        [JsonProperty("value")]
        public float Value { get; private set; }

        /// <summary>
        /// Responsável pelo subsídio
        /// </summary>
        [JsonProperty("sponsorshipValues")]
        public SponsorshipValues SponsorshipValues { get; private set; }

        /// <summary>
        /// Desconto em um item específico
        /// </summary>
        [JsonProperty("target")]
        public string Target { get; private set; }

        /// <summary>
        /// ID do item promocional
        /// </summary>
        [JsonProperty("targetId")]
        public string TargetId { get; private set; }

        public Benefit()
        {

        }

        public Benefit(float value, SponsorshipValues sponsorshipValues, string target, string targetId)
        {
            Value = value;
            SponsorshipValues = sponsorshipValues;
            Target = target;
            TargetId = targetId;
        }
    }
}
