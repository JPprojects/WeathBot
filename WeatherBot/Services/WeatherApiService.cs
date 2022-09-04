using Microsoft.AspNetCore.Mvc;
using WeatherBot.Helpers;
using WeatherBot.Interfaces;
using WeatherBot.Models;

namespace WeatherBot.Services
{
    public class WeatherApiService : IWeatherAPIService
    {
        public async Task<WeatherModel> ApiCall()
        {
            ApiHelper.InitializeClient();

            string url = "weather?q=London,uk&APPID=a3bec6cae5be523e8f91b317166bfe18";

            //At the end of the using statement it will close the call. Prevents their being several ports open at one time. Helps memory management and network management
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    //readAsAsync will take the json and try to convert it to the weather model, does not care about anything thats not in the model
                    WeatherModel weather = await response.Content.ReadAsAsync<WeatherModel>();

                    return weather;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
