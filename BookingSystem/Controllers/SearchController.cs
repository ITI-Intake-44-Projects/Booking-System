using AutoMapper;
using BookingSystem.Models;
using BookingSystem.Repository;
using BookingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookingSystem.Controllers
{
    public class SearchController : Controller
    {
        private readonly IHotelRepository hotelRepository;
        private readonly IMapper mapper;
        private readonly INonHotelRepository nonHotelRepository;

        public SearchController(IHotelRepository hotelRepository,IMapper mapper ,INonHotelRepository nonHotelRepository)
        {
            this.hotelRepository = hotelRepository;
            this.mapper = mapper;
            this.nonHotelRepository = nonHotelRepository;
        }
        public IActionResult Index(string city)
        {
            var Hotelslist = hotelRepository.GetHotelsByCity(city);
            var NonHotelsList = nonHotelRepository.GetNonHotelsByCity(city);

            var hotelsMapped = mapper.Map<List<Hotel>, List<SearchPlacesVm>>(Hotelslist);
            var nonHotelsMapped = mapper.Map<List<NonHotel>, List<SearchPlacesVm>>(NonHotelsList);

            var places = hotelsMapped.Concat(nonHotelsMapped).ToList();

            return View("PlacesAtSearchedCity",places);
        }
    }
}
