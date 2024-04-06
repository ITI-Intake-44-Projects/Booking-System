using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookingSystem.Models;
using BookingSystem.ViewModels;

using System.Collections.Generic;
using BookingSystem.Repository;
using AutoMapper;


namespace BookingSystem.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository room;
        private readonly IMapper mapper;

        public RoomController(IRoomRepository room ,IMapper mapper)
        {
            this.room = room;
            this.mapper = mapper;
        }
        
 
        //[HttpGet]
        public IActionResult Index(int id , string type)
        {
           if (type == "Hotel")
           {
                Rooms(id);
           }
           else
           {

           }

            return View();
        }

        public IActionResult Rooms(int id) 
        {
            var rooms = room.GetRoomsByHotel(id);
            List<RoomViewModel> roomsVm = mapper.Map<List<Room>,List<RoomViewModel>>(rooms);
        
            return View("Index",roomsVm);
        }






    }
}