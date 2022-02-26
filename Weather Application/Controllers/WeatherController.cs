using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Weather_Application.Models;
using Weather_Application.Services;

namespace Weather_Application.Controllers
{
    [ApiController]
    [Route("weather")]
    [Authorize]
    public class WeatherController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WeatherLookupService _weatherLookupService;

        public WeatherController(ILogger<HomeController> logger, WeatherLookupService weatherLookupService)
        {
            _logger = logger;
            _weatherLookupService = weatherLookupService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("query")]
        public async Task<IActionResult> GetWeatherData(string query)
        {
            if(query == null)
            {
                throw new NullReferenceException("Query is required");
            }
            try
            {
                var weatherData = await _weatherLookupService.GetWeatherData(query);
                return View("ViewWeatherData", weatherData);
            }
            catch(Exception ex)
            {
                return View("Index");
            }
        }
    }
}
