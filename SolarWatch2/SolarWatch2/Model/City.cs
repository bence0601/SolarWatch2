namespace SolarWatch2.Model
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GeoCodingApiResponse GeoCodingApiResponse { get; set; }
        public SunriseSunsetResult SunriseSunsetResult { get; set; }

    }
}
