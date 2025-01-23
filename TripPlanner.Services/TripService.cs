using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
