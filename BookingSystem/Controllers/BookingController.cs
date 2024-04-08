using BookingSystem.Models;
using BookingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{ 
     public class BookingController : Controller
        {

        private readonly BookingContext _context;

        public BookingController(BookingContext context)
        {
            _context = context;
        }
        public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(BookingViewModel model)
            {
                // Process the booking form submission
                if (ModelState.IsValid)
                {
                    // Save the booking details to the database
                    // Redirect to a confirmation page
                }
                // If model state is not valid, return to the booking form view with validation errors
                return View(model);
            }
        }
    }

