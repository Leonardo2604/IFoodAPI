using Newtonsoft.Json;
using System.Collections.Generic;

namespace IFoodAPI.Models
{
    public class SellingOption
    {
        /// <summary>
        /// Minimo permitido para compra
        /// </summary>
        [JsonProperty("minimum")]
        public int Mininum { get; set; }

        /// <summary>
        /// Incremental permitido pelo mercado
        /// </summary>
        [JsonProperty("incremental")]
        public int Incremental { get; set; }

        /// <summary>
        /// Unidades de venda do produto
        /// </summary>
        [JsonProperty("availableUnits")]
        public List<string> AvailableUnits { get; set; }

        /// <summary>
        /// Valor médio de uma unidade
        /// </summary>
        [JsonProperty("averageUnit")]
        public float AverageUnit { get; set; }
    }
}
