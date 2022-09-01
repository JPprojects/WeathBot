using WeatherBot.Models;

namespace WeatherBot.Interfaces
{
    public interface IWeatherAPIService
    {
        Task<WeatherModel> ApiCall();
    }
}
