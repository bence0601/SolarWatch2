namespace SolarWatch2.Services
{
    public class WeatherProvider : IWeatherDataProvider
    {
        private readonly ILogger<WeatherProvider> _logger;
        private readonly string Apikey = "940ee215a46a25240a4eb526b1d881e4";


        public WeatherProvider(ILogger<WeatherProvider> logger)
        {
            _logger = logger;
        }
        public async Task<string> GetLatLon(string city)
        {

            var geoUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={Apikey}";
            using var Client = new HttpClient();
            _logger.LogInformation("Getting data from URL");

            var response = await Client.GetAsync(geoUrl);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
