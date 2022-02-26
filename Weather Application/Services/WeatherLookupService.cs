using Microsoft.Extensions.Options;
using Weather_Application.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Weather_Application.Services
{
    public class WeatherLookupService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<WeatherAPIModel> _options;

        public WeatherLookupService(HttpClient httpClient, IOptions<WeatherAPIModel> options)
        {
            _httpClient = httpClient;
            _options = options;
        }

        public async Task<WeatherModel> GetWeatherData(string query)
        {
            var url = BuildWeatherQuery(query);
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Request has failed");
            }

            var seralizedResponse = await response.Content.ReadAsStringAsync();
            var weatherModelResponse = JsonConvert.DeserializeObject<WeatherModel>(seralizedResponse);

            return weatherModelResponse;
        }

        private string BuildWeatherQuery(string query)
        {
            var url = _options.Value.BaseUrl;
            var queryParameters = $"key={_options.Value.Key}&q={query}";

            return $"{url}{queryParameters}";
        }
    }
}
