using Newtonsoft.Json;

namespace WeatherBot.Models
{
    public class WeatherModel 
    {
        public object Weather { get; set; }

        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Exception ErrorMessage;
    }
}
