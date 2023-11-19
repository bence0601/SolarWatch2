namespace SolarWatch2.Services
{
    public interface IWeatherDataProvider
    {
        Task<string> GetLatLon(string city);
    }
}
