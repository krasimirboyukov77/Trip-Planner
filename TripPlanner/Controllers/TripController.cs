using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripPlanner.Data;
using TripPlanner.Data.Models;
using TripPlanner.ViewModels;

namespace TripPlanner.Controllers
{
    public class TripController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public TripController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var trips = await _dbContext.Trips.Select(t=> new TripInfoViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Destination = t.Destination,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                Description = t.Description,
            }).ToListAsync();


            return View(trips);
        }

        [HttpGet]
        public IActionResult TripCreate()
        {
            var trip = new TripInfoViewModel();

            return View(trip);
        }


        [HttpPost]
        public async Task<IActionResult> TripCreate(TripInfoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            return View(viewModel);
        }
    }
}
