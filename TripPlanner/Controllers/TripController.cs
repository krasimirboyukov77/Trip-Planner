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

        public TripController(ITripService tripService)
        {
            this._tripService = tripService;
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
            
            var mapboxToken = "MapBox.Token";
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
