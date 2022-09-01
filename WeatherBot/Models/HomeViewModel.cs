namespace WeatherBot.Models
{
    //Inherit weather model to remove logic from model builder to map across, Status being set to know what the staus of the call is to the user
    public class HomeViewModel: WeatherModel
    {
        public string WeatherDescription { get; set; }
        public string Status { get; set; }
    }
}
