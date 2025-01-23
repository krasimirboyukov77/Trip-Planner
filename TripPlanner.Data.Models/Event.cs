using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Data.Models
{
    public class Event
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? Date { get; set; }

        [Required]
        public Guid TripId { get; set; }
        [ForeignKey(nameof(TripId))]
        public Trip Trip { get; set; } = null!;
    }
}
