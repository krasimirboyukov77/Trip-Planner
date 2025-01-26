using Microsoft.AspNetCore.Mvc;

namespace TripPlanner.Controllers
{
    public class PlacesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
