using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using System.Net;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiClient _apiClient;
        public HomeController(ILogger<HomeController> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public IActionResult Index()
        {
            List<State> lstState = new();
            RestResponse restResponse = _apiClient.Call("home/getstate", "GET");
            if (restResponse != null && restResponse.StatusCode == HttpStatusCode.OK)
                lstState = JsonConvert.DeserializeObject<List<State>>(restResponse.Content!)!;

            return View(lstState);
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