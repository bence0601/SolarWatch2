using Newtonsoft.Json;
using SolarWatch2.Model;
using System.Net;

namespace SolarWatch2.Services
{
    public class SunriseSunsetProvider : ISunriseSunsetProvider
    {
        private readonly ILogger<SunriseSunsetProvider> _logger;

        public SunriseSunsetProvider(ILogger<SunriseSunsetProvider> logger)
        {
            _logger = logger;
        }

        public IEnumerable<SunriseSunsetResult> GetSunriseSunset(double lat, double lon, DateTime startDate, DateTime endDate)
        {
            var url = $"https://api.sunrise-sunset.org/json?lat={lat}&lng={lon}&start={startDate:yyyy-MM-dd}&end={endDate:yyyy-MM-dd}";

            _logger.LogInformation("Calling SunriseSunset API with url: {url}");

            using (var client = new WebClient())
            {
                var jsonString = client.DownloadString(url);
                var result = JsonConvert.DeserializeObject<SunriseSunsetResult>(jsonString);

                return new List<SunriseSunsetResult> { result.Results };
            }
        }
    }
}