using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Data.Models
{
    public class Trip
    {
        public Trip()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Destination { get; set; } = null!;

        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; }

        public string? Description { get; set; }

        [Required]
        public Guid CreatorId { get; set; }
        [Required]
        [ForeignKey(nameof(CreatorId))]
        public ApplicationUser Creator { get; set; } = null!;

        public ICollection<TripUser> TripUsers { get; set; } = new HashSet<TripUser>();
        public ICollection<Hotel> Hotels { get; set; } = new HashSet<Hotel>();  
        public ICollection<Transportation> Transports { get; set; } = new HashSet<Transportation>();
        public ICollection<Event> Events { get; set; } = new HashSet<Event>();

    }
}
