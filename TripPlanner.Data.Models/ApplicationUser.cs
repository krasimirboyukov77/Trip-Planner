using Microsoft.AspNetCore.Identity;

namespace TripPlanner.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser() 
        {
            this.Id = Guid.NewGuid();
        }

        public ICollection<TripUser> UserTrip {  get; set; } = new HashSet<TripUser>(); 
    }
}
