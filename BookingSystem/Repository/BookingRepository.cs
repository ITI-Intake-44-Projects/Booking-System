using BookingSystem.Models;
using BookingSystem.ViewModels;

namespace BookingSystem.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private readonly ILocationRepository locationRepository;

        public BookingRepository(BookingContext _context, ILocationRepository locationRepository) : base(_context)
        {
            this.locationRepository = locationRepository;
        }

        public List<MostVisitedPlacesViewModel> GetMostVisitedPlaces()
        {
            return context.Bookings
                    .Where(h => h.RoomId != null && h.Room.Hotel.Location.City != null)
                    .GroupBy(o => o.Room.Hotel.Location.City)
                    .OrderByDescending(group => group.Count())
                    .Select(group => new MostVisitedPlacesViewModel
                    {
                        CityName = group.Key,
                        Visits = group.Count(),
                        CityImage = locationRepository.GetCityImage(group.Key)
                    })
                    .Take(5)
                    .ToList();
        }
    }
}
