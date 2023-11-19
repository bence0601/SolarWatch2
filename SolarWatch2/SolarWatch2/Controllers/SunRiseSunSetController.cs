using Microsoft.AspNetCore.Mvc;
using SolarWatch2.Model;
using SolarWatch2.Services;
using SolarWatch2.Services.JSON;

namespace SolarWatch2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SunRiseSunSetController : ControllerBase
    {
        private readonly ILogger<SunRiseSunSetController> _logger;
        private readonly IWeatherDataProvider _weatherDataProvider;
        private readonly IJsonProcessor _jsonProcessor;

        public SunRiseSunSetController(ILogger<SunRiseSunSetController> logger, IWeatherDataProvider weatherDataProvider, IJsonProcessor jsonProcessor)
        {
            _logger = logger;
            _weatherDataProvider = weatherDataProvider;
            _jsonProcessor = jsonProcessor;
        }


        [HttpGet("GetByName")]
        public async Task<ActionResult<SunriseSunsetResult>> GetSunriseSunset(string cityname, DateTime date)
        {
            var GeoData = await _weatherDataProvider.GetLatLon(cityname);
            var GeoResult = _jsonProcessor.GetGeoCodingApiResponse(GeoData);
            var lat = GeoResult.Lat;
            var lon = GeoResult.Lon;
            var sunrisesunsetresult = new SunriseSunsetResult();
            Console.WriteLine($"{lat},{lon}");
            return Ok(sunrisesunsetresult);
        }

    }
}
