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

        public async Task<IActionResult> Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 7;

            var hotels = await hotelRepository.GetByPageAsync(pageNumber, pageSize);

            var totalHotels = await hotelRepository.GetCountAsync();

            var totalPages = (int)Math.Ceiling(totalHotels / (double)pageSize);

            var viewModel = new HotelListViewModel
            {
                PageNumber = pageNumber,
                TotalPages = totalPages,
                Hotels = hotels.Select(h => new HotelViewModel
                {
                    HotelId = h.HotelId,
                    Name = h.Name,
                    //HotelType = h.HotelType,
                    HotelDescription = h.HotelDescription,
                    City = h.Location?.City,
                    Country = h.Location?.Country,
                    //Image = h.HotelImages.FirstOrDefault()?.Image,

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
        public async Task<IActionResult> Create(InsertHotelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingLocation = context.Locations.FirstOrDefault(loc => loc.City == model.City && loc.Country == model.Country);

                Location location;
                Hotel hotel;

                if (existingLocation == null)
                {
                    location = new Location { Country = model.Country, City = model.City };
                    context.Locations.Add(location);
                }
                else
                {
                    location = existingLocation;
                }

                //byte[]? imageData = null;
                //if (model.ImageFile != null && model.ImageFile.Length > 0)
                //{
                //    using (var memoryStream = new MemoryStream())
                //    {
                //        await model.ImageFile.CopyToAsync(memoryStream);
                //        imageData = memoryStream.ToArray();
                //    }
                //}

                hotel = new Hotel { Name = model.Name, Location = location, HotelDescription=model.HotelDescription};

                context.Add(hotel);
                await context.SaveChangesAsync();

                //if (imageData != null)
                //{
                //    var hotelImage = new HotelImages { Image = imageData, HotelId = hotel.HotelId };
                //    context.Add(hotelImage);
                //    await context.SaveChangesAsync();
                //}

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await context.Hotels.Include(h => h.Location).FirstOrDefaultAsync(h => h.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }

            var viewModel = new EditHotelViewModel
            {
                HotelId = hotel.HotelId,
                Name = hotel.Name,
                //HotelType = hotel.HotelType,
                HotelDescription = hotel.HotelDescription,
                City = hotel.Location.City,
                Country = hotel.Location.Country,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditHotelViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var hotel = await context.Hotels.Include(h => h.Location).FirstOrDefaultAsync(h => h.HotelId == id);

                    if (hotel == null)
                    {
                        return NotFound();
                    }

                    hotel.Name = model.Name;
                    hotel.Location.City = model.City;
                    //hotel.HotelType = model.HotelType;
                    hotel.Location.Country = model.Country;
                    hotel.HotelDescription = model.HotelDescription;

                    context.Update(hotel);
                    await context.SaveChangesAsync();
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await hotelRepository.GetByIdIncludeLocationAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            var viewModel = new HotelViewModel
            {
                HotelId = hotel.HotelId,
                Name = hotel.Name,
                HotelDescription = hotel.HotelDescription,
                City = hotel.Location.City,
                Country = hotel.Location.Country
                /// img
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var hotel = await hotelRepository.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound();
            }

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