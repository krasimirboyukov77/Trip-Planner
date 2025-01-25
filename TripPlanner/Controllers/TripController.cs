using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripPlanner.Data;
using TripPlanner.Data.Models;
using TripPlanner.Services.Interfaces;
using TripPlanner.ViewModels;

namespace TripPlanner.Controllers
{
    public class TripController : Controller
    {
        private readonly ITripService _tripService;
        private readonly IConfiguration _configuration;

        public TripController(ITripService tripService,
            IConfiguration configuration)
        {
            this._tripService = tripService;
            this._configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var trips = await _tripService.GetTripsDetails();

            return View(trips);
        }

        [HttpGet]
        public IActionResult TripCreate()
        {
            var trip = new TripInfoViewModel();
            
            var mapboxToken = _configuration["API Token:Mapbox:AccessToken"];
            ViewBag.MapboxToken = mapboxToken;

            return View(trip);
        }


        [HttpPost]
        public async Task<IActionResult> TripCreate(TripInfoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            await _tripService.CreateTripAsync(viewModel);

            return View(viewModel);
        }
    }
}
