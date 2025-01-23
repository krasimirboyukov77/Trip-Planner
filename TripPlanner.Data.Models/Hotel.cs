using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Data.Models
{
    public class Hotel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Destination { get; set; }
        [Required]
        public Guid TripId { get; set; }
        [ForeignKey(nameof(TripId))]
        public Trip Trip { get; set; } = null!;
    }
}
