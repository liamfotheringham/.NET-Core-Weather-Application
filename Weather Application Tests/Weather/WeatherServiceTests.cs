using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Application.Services;
using Weather_Application_Tests.Shared.CustomWebApplicationFactory;
using Xunit;

namespace Weather_Application_Tests.Weather
{
    [Collection("waf")]
    public class WeatherServiceTests : TestBase, IAsyncLifetime
    {
        private readonly IServiceProvider _serviceProvider;

        public WeatherServiceTests(WebApplicationFixture webApplicationFixture) :
        base(webApplicationFixture.Factory)
        {
            _serviceProvider = Factory.Services.CreateScope().ServiceProvider;
        }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
        }

        [Fact]
        public async Task ShouldReturnCorrectLocationInformationEdinburgh()
        {
            //Arrange
            var location = "Edinburgh";
            var weatherService = _serviceProvider.GetRequiredService<WeatherLookupService>();

            //Act
            var response = await weatherService.GetWeatherData(location);

            //Assert
            Assert.Equal(location, response.Location.Name);
            Assert.Equal("City of Edinburgh", response.Location.Region);
            Assert.Equal(55.95, Math.Round(response.Location.Lat, 2));
            Assert.Equal(-3.16, Math.Round(response.Location.Lon, 2));
        }
    }
}
