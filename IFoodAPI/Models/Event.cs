using Newtonsoft.Json;
using System;

namespace IFoodAPI.Models
{
    public class Event
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("code")]
        public string Code { get; private set; }

        [JsonProperty("correlationId")]
        public string CorrelationId { get; private set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; private set; }

        public Event()
        {

        }

        public Event(string id, string code, string correlationId, DateTime createdAt)
        {
            Id = id;
            Code = code;
            CorrelationId = correlationId;
            CreatedAt = createdAt;
        }
    }
}
