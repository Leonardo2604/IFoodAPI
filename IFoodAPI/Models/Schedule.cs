using Newtonsoft.Json;
using System;

namespace IFoodAPI.Models
{
    public class Schedule
    {
        [JsonProperty("dayOfWeek")]
        public string DayOfWeek { get; set; }

        [JsonProperty("beginHour")]
        public DateTime BeginHour { get; set; }

        [JsonProperty("endHour")]
        public DateTime EndHour { get; set; }
    }
}
