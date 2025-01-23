using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Data.Models
{
    public class TripUser
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        public Guid TripId { get; set; }
        [Required]
        [ForeignKey(nameof(TripId))]
        public Trip Trip { get; set; } = null!;
    }
}
