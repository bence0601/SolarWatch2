namespace SolarWatch2.Model
{
    public class SunriseSunset
    {
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
    }

    public class SunriseSunsetResult
    {
        public SunriseSunsetResult Results { get; set; }
    }
}