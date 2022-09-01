using WeatherBot.Models;

namespace WeatherBot.Interfaces
{
    public interface IHomeViewModelBuilder
    {
        Task<HomeViewModel> BuildAsync();
    }
}
