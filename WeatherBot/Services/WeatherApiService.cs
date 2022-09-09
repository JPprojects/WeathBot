using Microsoft.AspNetCore.Mvc;
using WeatherBot.Helpers;
using WeatherBot.Interfaces;
using WeatherBot.Models;

namespace WeatherBot.Services
{
    public class WeatherApiService : IWeatherAPIService
    {
        public async Task<WeatherModel> BuildWeatherModel()
        {
            string url = "weather?q=London,uk&APPID=a3bec6cae5be523e8f91b317166bfe18";

            var response = await ApiHelper.GetResponseMessage(url);

            //At the end of the using statement it will close the call. Prevents their being several ports open at one time. Helps memory management and network management
            using (response)
            {               
                //readAsAsync will take the json and try to convert it to the weather model, does not care about anything thats not in the model
                var weather = await response.Content.ReadAsAsync<WeatherModel>();

                return weather;
            }
        }
    }
}
