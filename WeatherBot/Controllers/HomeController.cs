using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using WeatherBot.Interfaces;
using WeatherBot.Models;

namespace WeatherBot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //refrence interface as a readonly to make it closed for modifictation, allows refrence to method.
        private readonly IHomeViewModelBuilder _homeViewModelBuilder;

        public HomeController(ILogger<HomeController> logger, IHomeViewModelBuilder homeViewModelBuilder)
        {
            _logger = logger;
            //define what the Ineterface is and remove the concrete depandency on the viewmodelbuilder
            _homeViewModelBuilder = homeViewModelBuilder;
        }

        public IActionResult Index()
        {
            _homeViewModelBuilder.Build();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void apiCall()
        {
            HttpClient client = new HttpClient();
            var url = "https://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=a3bec6cae5be523e8f91b317166bfe18";

            HttpResponseMessage response = client.GetAsync(url).Result;


            if (response.IsSuccessStatusCode)
            {
                var readableResult = response.Content.ReadAsStringAsync();
                // Parse the response body.
                Console.WriteLine(readableResult);
            }
        }
    }
}