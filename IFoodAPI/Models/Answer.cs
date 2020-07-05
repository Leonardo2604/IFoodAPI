using Newtonsoft.Json;

namespace IFoodAPI.Models
{
    public class Answer
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("title")]
        public string Title { get; private set; }

        [JsonProperty("value")]
        public string Value { get; private set; }

        public Answer(string id, string title, string value)
        {
            Id = id;
            Title = title;
            Value = value;
        }
    }
}
