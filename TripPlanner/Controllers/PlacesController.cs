using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TripPlanner.Models;
using TripPlanner.ViewModels.PlacesViewModels;

public class PlacesController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _googleApiKey;

    public PlacesController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _googleApiKey = configuration["API Token:Mapbox:Places"];
    }

    // This will be triggered when the form is submitted with the city name
    public async Task<IActionResult> Index(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            return View("Error", new ErrorViewModel { Message = "City name is required." });
        }

        var client = _httpClientFactory.CreateClient();

        // Geocoding API request to get coordinates of the city
        var geocodeUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={city}&key={_googleApiKey}";
        var geocodeResponse = await client.GetAsync(geocodeUrl);

        if (!geocodeResponse.IsSuccessStatusCode)
        {
            return View("Error", new ErrorViewModel { Message = "Unable to get city coordinates." });
        }

        var geocodeData = await geocodeResponse.Content.ReadAsStringAsync();
        var geocodeResult = JsonConvert.DeserializeObject<GeocodeResponse>(geocodeData);

        if (geocodeResult.results.Count == 0)
        {
            return View("Error", new ErrorViewModel { Message = "City not found." });
        }

        var location = geocodeResult.results[0].geometry.location;
        double lat = location.lat;
        double lng = location.lng;

        // Use the coordinates to get places near the city
        var placesUrl = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={lat},{lng}&radius=5000&key={_googleApiKey}";
        var placesResponse = await client.GetAsync(placesUrl);

        if (!placesResponse.IsSuccessStatusCode)
        {
            return View("Error", new ErrorViewModel { Message = "Unable to fetch places data." });
        }

        var placesData = await placesResponse.Content.ReadAsStringAsync();
        var placesResult = JsonConvert.DeserializeObject<PlacesResponse>(placesData);

        // Preprocess image URLs for each place
        foreach (var place in placesResult.results)
        {
            if (place.photos != null && place.photos.Count > 0)
            {
                place.ImageUrl = $"https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference={place.photos[0].photo_reference}&key={_googleApiKey}";
            }
            else
            {
                place.ImageUrl = "https://via.placeholder.com/400x300?text=No+Image";
            }
        }

        ViewData["City"] = city;
        return View(placesResult.results);
    }


}
