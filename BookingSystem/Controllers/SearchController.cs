using AutoMapper;
using BookingSystem.Models;
using BookingSystem.Repository;
using BookingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    public class SearchController : Controller
    {
        private readonly IHotelRepository hotelRepository;
        private readonly IMapper mapper;

        public SearchController(IHotelRepository hotelRepository,IMapper mapper)
        {
            this.hotelRepository = hotelRepository;
            this.mapper = mapper;
        }
        public IActionResult Index(string city)
        {
            var list = hotelRepository.GetHotelsByCity(city);
            var Hotels = mapper.Map<List<Hotel>, List<SearchPlacesVm>>(list);

            return View("PlacesAtSearchedCity",Hotels);
        }
    }
}
