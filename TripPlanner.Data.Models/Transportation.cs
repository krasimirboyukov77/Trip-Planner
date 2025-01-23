using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Data.Models.Enum;

namespace TripPlanner.Data.Models
{
    public class Transportation
    {
        public Guid Id { get; set; }
        public Transport Vehicle { get; set; }
        public DateTime Duration { get; set; }

        [Required]
        public Guid TripId { get; set; }
        [ForeignKey(nameof(TripId))]
        public Trip Trip { get; set; } = null!;
    }
}
