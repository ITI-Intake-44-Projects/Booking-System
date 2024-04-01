using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View("PlacesAtSearchedCity");
        }
    }
}
