using Newtonsoft.Json;
using System.Collections.Generic;

namespace IFoodAPI.Models
{
    public class Question
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("type")]
        public string Type { get; private set; }

        [JsonProperty("title")]
        public string Title { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }

        [JsonProperty("answers")]
        public List<Answer> Answers { get; private set; }

        public Question(string id, string type, string title, string description, List<Answer> answers)
        {
            Id = id;
            Type = type;
            Title = title;
            Description = description;
            Answers = answers;
        }
    }
}
