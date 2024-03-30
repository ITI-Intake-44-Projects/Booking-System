using BookingSystem.Models;
using BookingSystem.Repository;
using BookingSystem.ViewModels;
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
        private readonly ILocationRepository locationRepository;
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger, BookingContext db, IBookingRepository bookingRepository, ILocationRepository locationRepository)
        {
            this.db = db;
            this.logger = logger;
            this.bookingRepository = bookingRepository;
            this.locationRepository = locationRepository;
        }


        //[Authorize]
        public IActionResult Index()
        {
            var top5places = bookingRepository.GetMostVisitedPlaces();

            var mostVisitedPlaces = top5places.Select(group => new MostVisitedPlacesViewModel{
                CityName = group.Key,
                Visits = group.Count(),
                CityImage = locationRepository.GetCityImage(group.Key)
            }).ToList();

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
