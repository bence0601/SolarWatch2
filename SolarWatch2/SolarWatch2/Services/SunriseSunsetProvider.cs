using SolarWatch2.Model;
using System.Globalization;
using System.Net;
using System.Text.Json;

namespace SolarWatch2.Services
{
    public class SunriseSunsetProvider : ISunriseSunsetProvider
    {
        private readonly ILogger<SunriseSunsetProvider> _logger;

        public SunriseSunsetProvider(ILogger<SunriseSunsetProvider> logger)
        {
            _logger = logger;
        }

        public SunriseSunset GetSunriseSunset(double lat, double lon, DateTime date)
        {
            var url = $"https://api.sunrise-sunset.org/json?lat={lat}&lng={lon}&date={date:yyyy-MM-dd}";
            var client = new WebClient();

            try
            {
                var jsonString = client.DownloadString(url);
                var result = JsonSerializer.Deserialize<ApiResult>(jsonString);

                if (result != null && result.Results != null)
                {
                    var dateFormat = "h:mm:ss tt";
                    var culture = CultureInfo.InvariantCulture;

                    return new SunriseSunset
                    {
                        Date = date,
                        Sunrise = DateTime.ParseExact(result.Results.Sunrise, dateFormat, culture),
                        Sunset = DateTime.ParseExact(result.Results.Sunset, dateFormat, culture)
                    };
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting SunriseSunset Data");
            }

            return null; // Or handle the error in a way that makes sense for your application
        }

        // Define a class to represent the structure of the JSON response
        private class ApiResult
        {
            public Results Results { get; set; }
            public string Status { get; set; }
        }

        private class Results
        {
            public string Sunrise { get; set; }
            public string Sunset { get; set; }
        }
    }
}