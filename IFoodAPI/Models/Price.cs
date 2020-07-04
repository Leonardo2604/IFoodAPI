using Newtonsoft.Json;
using System;

namespace IFoodAPI.Models
{
    public class Price
    {
        /// <summary>
        /// Valor do item (Valor que vai para aparecer na plataforma Ifood)
        /// </summary>
        [JsonProperty("value")]
        public float Value { get; set; }

        /// <summary>
        /// Valor Original do Item (Somente preencher caso o item estiver em promoção)
        /// </summary>
        [JsonProperty("originalValue")]
        public float OriginalValue { get; set; }

        [JsonProperty("validFrom")]
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Item está em promoção?
        /// </summary>
        [JsonProperty("promotional")]
        public bool Promotional { get; set; }
    }
}
