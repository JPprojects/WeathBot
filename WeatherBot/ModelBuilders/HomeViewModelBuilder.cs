using Newtonsoft.Json.Linq;
using System.Reflection;
using WeatherBot.Interfaces;
using WeatherBot.Models;

namespace WeatherBot.ModelBuilders
{
    public class HomeViewModelBuilder: IHomeViewModelBuilder
    {
        private readonly IWeatherAPIService _weatherAPIService;
        public HomeViewModelBuilder(IWeatherAPIService weatherAPIService)
        {
            //define what the Ineterface is and remove the concrete depandency on the viewmodelbuilder
            _weatherAPIService = weatherAPIService;
        }

        public async Task<HomeViewModel> BuildAsync()
        {
            WeatherModel weather = new WeatherModel();

            weather = await _weatherAPIService.ApiCall().ConfigureAwait(false);

            HomeViewModel viewModel = new HomeViewModel();

            if (weather != null)
            {

                Type myType = weather.Weather.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

                foreach (PropertyInfo prop in props)
                {
                    object propValue = prop.GetValue(weather.Weather, null);

                    propValue.

                    // Do something with propValue
                }


                //viewModel.WeatherDescription = string.Format((str);
                viewModel.Name = weather.Name;
                viewModel.Status = "Running fine";
            }
            else
            {
                viewModel.Status = "Oops something went wrong";
            }


            return viewModel;
        }

        private static Dictionary<string, string> GetProperties(object obj)
        {
            var props = new Dictionary<string, string>();
            if (obj == null)
                return props;

            var type = obj.GetType();
            foreach (var prop in type.GetProperties())
            {
                var val = prop.GetValue(obj, new object[] { });
                var valStr = val == null ? "" : val.ToString();
                props.Add(prop.Name, valStr);
            }

            return props;
        }
    }
}
