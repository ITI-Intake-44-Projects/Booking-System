using BookingSystem.Models;
using BookingSystem.Repository;
using BookingSystem.ViewModels;
using BookingSystem.ViewModels.HotelViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Controllers
{
    public class NonHotelController : Controller
    {
        private readonly BookingContext context;
        private readonly IRepository<NonHotel> repository;
        private readonly INonHotelRepository nonhotelRepository;

        public NonHotelController(BookingContext context, INonHotelRepository nonhotelRepository, IRepository<NonHotel> repository)
        {
            this.context = context;
            this.repository = repository;
            this.nonhotelRepository = nonhotelRepository;
        }
        //Get
        public async Task<IActionResult> Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;

            var nonhotels = await nonhotelRepository.GetByPageAsync(pageNumber, pageSize);

            var totalnonHotels = await nonhotelRepository.GetCountAsync();

            var totalPages = (int)Math.Ceiling(totalnonHotels / (double)pageSize);

            var viewModel = new NonHotelListViewModel
            {
                PageNumber = pageNumber,
                TotalPages = totalPages,
                NonHotels = nonhotels.Select(h => new NonHotelViewModel
                {
                    NonHotelId = h.NonHotelId,
                    Name = h.Name,
                    Description = h.Description,
                    Reserved = h.Reserved,
                    City = h.Location?.City,
                    Country = h.Location?.Country,
                }).ToList(),
            };
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsertNonHotelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingLocation = context.Locations.FirstOrDefault(loc => loc.City == model.City && loc.Country == model.Country);

                Location location;
                NonHotel nonhotel;

                if (existingLocation == null)
                {
                    location = new Location { Country = model.Country, City = model.City };
                    context.Locations.Add(location);
                }
                else
                {
                    location = existingLocation;
                }
                nonhotel = new NonHotel { Name = model.Name, Location = location, Description = model.Description , Reserved = model.Reserved};

                context.Add(nonhotel);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        //update
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nonhotel = await context.NonHotels.Include(h => h.Location).FirstOrDefaultAsync(h => h.NonHotelId == id);
            if (nonhotel == null)
            {
                return NotFound();
            }

            var viewModel = new EditNonHotelViewModel
            {
                NonHotelId = nonhotel.NonHotelId,
                Name = nonhotel.Name,
                Reserved = nonhotel.Reserved,
                Description = nonhotel.Description,
                City = nonhotel.Location.City,
                Country = nonhotel.Location.Country,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditNonHotelViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var nonhotel = await context.NonHotels.Include(h => h.Location).FirstOrDefaultAsync(h => h.NonHotelId == id);

                    if (nonhotel == null)
                    {
                        return NotFound();
                    }

                    nonhotel.Name = model.Name;
                    nonhotel.Location.City = model.City;
                    nonhotel.Location.Country = model.Country;
                    nonhotel.Reserved = model.Reserved;
                    nonhotel.Description = model.Description;

                    context.Update(nonhotel);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NonHotelExists(model.NonHotelId))
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
        private bool NonHotelExists(int id)
        {
            return context.NonHotels.Any(e => e.NonHotelId == id);
        }

        //delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nonhotel = await context.NonHotels.Include(h => h.Location).FirstOrDefaultAsync(h => h.NonHotelId == id);
            if (nonhotel == null)
            {
                return NotFound();
            }

            var viewModel = new NonHotelViewModel
            {
                NonHotelId = nonhotel.NonHotelId,
                Name = nonhotel.Name,
                Reserved = nonhotel.Reserved,
                Description = nonhotel.Description,
                City = nonhotel.Location.City,
                Country = nonhotel.Location.Country
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var nonhotel = await context.NonHotels.FirstOrDefaultAsync(h => h.NonHotelId == id);
            if (nonhotel == null)
            {
                return NotFound();
            }

            repository.Delete(nonhotel);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
