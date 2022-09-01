using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            var viewmodel = _homeViewModelBuilder.BuildAsync();
            return View(viewmodel);
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
    }
}