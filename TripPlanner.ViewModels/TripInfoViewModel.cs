using System.ComponentModel.DataAnnotations;
using TripPlanner.Common.Constants;
using TripPlanner.Common.ErrorMessages;

namespace TripPlanner.ViewModels
{
    public class TripInfoViewModel
    {

        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(
            ValidationConstants.TripNameMaxLength, 
            ErrorMessage = ErrorMessages.TripNameErrorMessage, 
            MinimumLength = ValidationConstants.TripNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(
            ValidationConstants.TripDestinationMaxLength,
            ErrorMessage = ErrorMessages.TripDestnationErrorMessage,
            MinimumLength = ValidationConstants.TripDestinationMinLength)]
        public string Destination { get; set; } = null!;

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [MaxLength(ValidationConstants.TripDescriptionMaxLength, ErrorMessage = ErrorMessages.TripDescriptionErrorMessage)]
        public string? Description { get; set; }
    }
}
