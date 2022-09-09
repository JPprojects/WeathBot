using System.Net.Http.Headers;

namespace WeatherBot.Helpers
{
    public class ApiHelper
    {
        private static readonly HttpClient _httpClient;

        //Instatiate named client
        //private static readonly HttpClientFactory _httpClient2;
        //var client = _httpClient2.CreateClient("weatherApi");


        public static async Task<HttpResponseMessage> GetResponseMessage(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode) { return null; }

            return response;
        }
    }
}
