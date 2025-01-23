using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Common.ErrorMessages
{
    public class ErrorMessages
    {
        public const string TripNameErrorMessage = "Trip name must be between 3 and 100 characters!";
        public const string TripDestnationErrorMessage = "Destination name must be between 1 and 250 characters!";
        public const string TripDescriptionErrorMessage = "Description must not exceed 800 characters!";
    }
}
