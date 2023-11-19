using SolarWatch2.Model;

namespace SolarWatch2.Services.JSON
{
    public interface IJsonProcessor
    {
        GeoCodingApiResponse GetGeoCodingApiResponse(string data);
    }
}
