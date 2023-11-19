using SolarWatch2.Model;
using System.Text.Json;

namespace SolarWatch2.Services.JSON
{
    public class JsonProcessor : IJsonProcessor
    {

        public GeoCodingApiResponse GetGeoCodingApiResponse(string data)
        {
            JsonDocument Json = JsonDocument.Parse(data);
            JsonElement coord = Json.RootElement.GetProperty("coord");

            GeoCodingApiResponse response = new GeoCodingApiResponse()
            {
                Lat = coord.GetProperty("lat").GetDouble(),
                Lon = coord.GetProperty("lon").GetDouble()
            };
            return response;
        }
    }
}
