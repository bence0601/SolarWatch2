using SolarWatch2.Model;

namespace SolarWatch2.Services
{
    public interface ISunriseSunsetProvider
    {
        public SunriseSunset GetSunriseSunset(double lat, double lon, DateTime date);
    }
}
