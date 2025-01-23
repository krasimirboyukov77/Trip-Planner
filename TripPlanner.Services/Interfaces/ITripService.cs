using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.ViewModels;

namespace TripPlanner.Services.Interfaces
{
    public interface ITripService
    {
        Task<bool> CreateTripAsync(TripInfoViewModel viewModel);
    }
}
