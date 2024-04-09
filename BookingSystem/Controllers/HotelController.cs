using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Models;
using BookingSystem.ViewModels;
using Microsoft.EntityFrameworkCore;
using BookingSystem.Repository;
using BookingSystem.ViewModels.HotelViewModels;

namespace BookingSystem.Controllers
{
    public class HotelController : Controller
    {
        private readonly BookingContext context;
        private readonly IRepository<Hotel> repository;
        private readonly IHotelRepository hotelRepository;

        public HotelController(BookingContext context, IHotelRepository hotelRepository, IRepository<Hotel> repository)
        {
            this.context = context;
            this.repository = repository;
            this.hotelRepository = hotelRepository;
        }

        // GET: Hotel
        public async Task<IActionResult> Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;

            var hotels = await hotelRepository.GetByPageAsync(pageNumber, pageSize);

            var totalHotels = await hotelRepository.GetCountAsync();

            var totalPages = (int)Math.Ceiling(totalHotels / (double)pageSize);

            var viewModel = new HotelListViewModel
            {
                Hotels = hotels.Select(h => new HotelViewModel
                {
                    HotelId = h.HotelId,
                    Name = h.Name,
                    HotelType = h.HotelType,
                    HotelDescription = h.HotelDescription,
                    Address = h.Address,
                    Location = new LocationViewModel
                    {
                        City = h.Location?.City,
                        Country = h.Location?.Country
                    }
                }).ToList(),
                PageNumber = pageNumber,
                TotalPages = totalPages
            };

            return View(viewModel);
        }

        // GET: Hotel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsertHotelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hotel = new Hotel
                {
                    Name = model.Name,
                    HotelType = model.HotelType,
                    HotelDescription = model.HotelDescription,
                    Location = new Location
                    {
                        Country = model.Country,
                        City = model.City
                    }
                };

                context.Add(hotel);
                await context.SaveChangesAsync(); //repository.Update(hotel);
                
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Hotel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await context.Hotels.Where(h => h.HotelId == id).Include(h => h.Location).FirstAsync();
            if (hotel == null)
            {
                return NotFound();
            }

            var viewModel = new EditHotelViewModel
            {
                HotelId = hotel.HotelId,
                Name = hotel.Name,
                HotelType = hotel.HotelType,
                HotelDescription = hotel.HotelDescription,
                City = hotel.Location.City,
                Country = hotel.Location.Country,
            };

            return View(viewModel);
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditHotelViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var hotel = await context.Hotels.Where(h => h.HotelId == id).Include(h => h.Location).FirstAsync();
                    
                    if (hotel == null)
                    {
                        return NotFound();
                    }

                    hotel.Name = model.Name;
                    hotel.HotelId = model.HotelId;
                    hotel.Location.City = model.City;
                    hotel.HotelType = model.HotelType;
                    hotel.Location.Country = model.Country;
                    hotel.HotelDescription = model.HotelDescription;

                    context.Update(hotel);
                    context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(model.HotelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw new DbUpdateConcurrencyException("failed to update data");
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Hotel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var hotel = await hotelRepository.GetByIdIncludeLocationAsync(id);

            if (hotel == null) {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var hotel = await hotelRepository.GetHotelById(id);
            
            repository.Delete(hotel);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
            return context.Hotels.Any(e => e.HotelId == id);
        }
    }
}
