using BookingSystem.Models;
using BookingSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookingContext db;
        private readonly IBookingRepository bookingRepository;
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger, BookingContext db, IBookingRepository bookingRepository)
        {
            this.db = db;
            this.logger = logger;
            this.bookingRepository = bookingRepository;
        }


        //[Authorize]
        public ActionResult Index()
        {
            var mostVisitedPlaces = bookingRepository.GetMostVisitedPlaces();
            return View("Index", mostVisitedPlaces);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
