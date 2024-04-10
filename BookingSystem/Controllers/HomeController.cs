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
        private readonly ILogger<HomeController> logger;
        private readonly IBookingRepository bookingRepository;
        private readonly ILocationRepository locationRepository;

        public HomeController(BookingContext db, ILogger<HomeController> logger, IBookingRepository bookingRepository, ILocationRepository locationRepository)
        {
            this.db = db;
            this.logger = logger;
            this.bookingRepository = bookingRepository;
            this.locationRepository = locationRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            try 
            {
                var topVisitedPlaces = bookingRepository.GetMostVisitedPlaces();

                var mostVisitedPlaces = topVisitedPlaces.Select(group => new MostVisitedPlacesViewModel {
                    CityName = group.Key,
                    CountryName = locationRepository.GetCountryByCityName(group.Key),
                    Visits = group.Count(),
                    CityImage = locationRepository.GetCityImage(group.Key)
                }).ToList();

                return View("Index", mostVisitedPlaces);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching data for home page");
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult RenderImagesUsingAJAX(string CountryName)
        {
            var images = locationRepository.GetImagesByCountryName(CountryName);
            return Json(images);
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