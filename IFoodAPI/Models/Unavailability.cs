using Newtonsoft.Json;
using System;

namespace IFoodAPI.Models
{
    public class Unavailability
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("storageId")]
        public string StorageId { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }

        [JsonProperty("authorId")]
        public string AuthorId { get; private set; }

        [JsonProperty("start")]
        public DateTime Start { get; private set; }

        [JsonProperty("end")]
        public DateTime End { get; private set; }

        public Unavailability()
        {

        }

        public Unavailability(
            string id,
            string storageId,
            string description,
            string authorId,
            DateTime start,
            DateTime end)
        {
            Id = id;
            StorageId = storageId;
            Description = description;
            AuthorId = authorId;
            Start = start;
            End = end;
        }



        // pink, rosa
    }
}
