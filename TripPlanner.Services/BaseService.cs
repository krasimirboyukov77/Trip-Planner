using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TripPlanner.Data.Models;
using TripPlanner.Services.Interfaces;

namespace TripPlanner.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        public BaseService(
            IHttpContextAccessor httpContextAccessor,
            Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._userManager = userManager;
        }
        public bool IsGuidValid(string? id, ref Guid parsedGuid)
        {

            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            bool isGuidValid = Guid.TryParse(id, out parsedGuid);
            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }

        public async Task<ApplicationUser?> GetUser(string id)
        {
            Guid userGuid = Guid.Empty;

            var isUserIdValid = Guid.TryParse(id, out userGuid);

            if (!isUserIdValid)
            {
                return null;
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            return user;
        }
        public Guid GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Guid.Empty;
            }
            if (Guid.TryParse(userId, out Guid userGuid))
            {

                return userGuid;
            }

            return Guid.Empty;
        }
    }
}
