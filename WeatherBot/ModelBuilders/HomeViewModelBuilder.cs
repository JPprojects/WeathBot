﻿using WeatherBot.Interfaces;
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
            var Weather = new WeatherModel();

            //cofigure await can save you reentering the request context. Very helpful if you are trying to parrell calls. 
            //Just doing await also does this but ConfigureAwait will stop the deadlocks that user may enter with out it
            Weather = await _weatherAPIService.BuildWeatherModel().ConfigureAwait(false);

            var viewModel = new HomeViewModel();

            if (Weather != null)
            {
                viewModel.WeatherDescription = Weather.Weather.Description;
                viewModel.Name = Weather.Name;
                viewModel.Status = "Running fine";
            }
            else
            {
                viewModel.Status = "Oops something went wrong";
            }


            return viewModel;
        }
    }
}
