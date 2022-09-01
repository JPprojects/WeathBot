using System.Net.Http.Headers;

namespace WeatherBot.Helpers
{
    public class ApiHelper
    {
        //make sure it opens up once per application. This isnt the norm but for this case its okay. Like having one brower
        public static HttpClient ApiClient { get; set; } 

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();

            //this adds a header that say give me json this makes it easier to parse into the models
            //ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
