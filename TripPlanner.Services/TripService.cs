using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

using TripPlanner.Data.Models;
using TripPlanner.Repository.Contracts;
using TripPlanner.Services.Interfaces;
using TripPlanner.ViewModels;

namespace TripPlanner.Services
{
    public class TripService : BaseService, ITripService
    {
        private readonly IRepository<Trip> _tripRepository;
        public TripService(
            IRepository<Trip> tripRepository,
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager
            ) 
            :base(httpContextAccessor, userManager)
         { 
            this._tripRepository = tripRepository;
         }

        public async Task<ICollection<TripInfoViewModel>> GetTripsDetails()
        {
            var trips = await _tripRepository.GetAllAttached()
                .AsNoTracking()
                .Select(t => new TripInfoViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Destination = t.Destination,
                    Description = t.Description,
                    StartDate = t.StartDate.ToString(),
                    EndDate = t.EndDate.ToString(),
                })
                .ToListAsync();

            return trips;
               
        }

        public async Task<bool> CreateTripAsync(TripInfoViewModel viewModel)
        {
            bool isValidStartDate = DateTime.TryParseExact(viewModel.StartDate, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate);

            if (!isValidStartDate)
            {
                return false;
            }

            bool isValidEndDate = DateTime.TryParseExact(viewModel.EndDate, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate);

            if (!isValidEndDate)
            {
                return false;
            }

            Trip trip = new Trip()
            {
                Name = viewModel.Name,
                Destination = viewModel.Destination,
                Description = viewModel.Description,
                StartDate = startDate,
                EndDate = endDate,
                CreatorId = GetUserId(),

            };

            await _tripRepository.AddAsync(trip);

            return true;
        }
    }
}
