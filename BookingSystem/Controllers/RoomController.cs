using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookingSystem.Models;
using BookingSystem.ViewModels;

using System.Collections.Generic;


namespace BookingSystem.Controllers
{
    public class RoomController : Controller
    {
        private readonly BookingContext _context;

        public RoomController(BookingContext context)
        {
            _context = context;
        }
        // GET: /Room/Index

 
        [HttpGet]
        public IActionResult Index()
        {
            List<Room> rooms = _context.Rooms.ToList();
            List<RoomViewModel> roomViewModels = rooms.Select(r => new RoomViewModel
            {
                /////  Add Image here 
                Description=r.Description,
                RoomID = r.RoomID,
                RoomType = r.RoomType,
                PriceOfNight = r.PriceOfNight.HasValue ? (decimal)r.PriceOfNight.Value : 0m, // Safely handle nullable decimal
/*                HotelName = r.HotelName,                               */// Assuming Room model has HotelName property
            }).ToList();

            return View(roomViewModels);
        }



    }
}