using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IFoodAPI.Models
{
    public class Review
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("user")]
        public User User { get; private set; }

        [JsonProperty("orderReference")]
        public string OrderReference { get; private set; }

        [JsonProperty("templateId")]
        public string TemplateId { get; private set; }

        [JsonProperty("questions")]
        public List<Question> Questions { get; private set; }

        [JsonProperty("comment")]
        public string Comment { get; private set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; private set; }

        [JsonProperty("status")]
        public string Status { get; private set; }

        [JsonProperty("score")]
        public string Score { get; private set; }

        public Review(
            string id,
            User user,
            string orderReference,
            string templateId,
            List<Question> questions,
            string comment,
            DateTime createdAt,
            string status,
            string score)
        {
            Id = id;
            User = user;
            OrderReference = orderReference;
            TemplateId = templateId;
            Questions = questions;
            Comment = comment;
            CreatedAt = createdAt;
            Status = status;
            Score = score;
        }
    }
}
