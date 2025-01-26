using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Http;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PlacesApiController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _googleApiKey;

    public PlacesApiController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _googleApiKey = configuration["API Token:Mapbox:Places"]; // Set this in appsettings.json
    }


    [HttpGet("search")]
    public async Task<IActionResult> Search(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
            return BadRequest("City name is required.");

        var client = _httpClientFactory.CreateClient();
        var requestUrl = $"https://maps.googleapis.com/maps/api/place/textsearch/json?query=popular+places+in+{city}&key={_googleApiKey}";
        var response = await client.GetAsync(requestUrl);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return Ok(jsonResponse);
        }

        return BadRequest("Unable to fetch data from Google Places API.");
    }
}
