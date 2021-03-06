﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace IFoodAPI.Models
{
    public class OptionGroup
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("externalCode")]
        public string ExternalCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sequence")]
        public int Sequence { get; set; }

        [JsonProperty("minQuantity")]
        public int MinQuantity { get; set; }

        [JsonProperty("maxQuantity")]
        public int MaxQuantity { get; set; }

        [JsonProperty("options")]
        public List<Sku> Options { get; set; }
    }
}
