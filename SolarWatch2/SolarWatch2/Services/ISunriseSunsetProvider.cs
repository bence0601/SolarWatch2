using SolarWatch2.Model;

namespace SolarWatch2.Services
{
    public interface ISunriseSunsetProvider
    {
        IEnumerable<SunriseSunsetResult> GetSunriseSunset(double lat, double lon, DateTime startDate, DateTime endDate);
    }
}
