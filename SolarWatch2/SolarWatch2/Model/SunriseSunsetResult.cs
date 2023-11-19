namespace SolarWatch2.Model
{
    public class SunriseSunsetResult
    {
        public DateTime Date { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public int Id { get; set; }

        public City City { get; set; }

    }
}