using BookingSystem.Models;
using BookingSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private readonly ILocationRepository locationRepository;

        public BookingRepository(BookingContext _context, ILocationRepository locationRepository) : base(_context)
        {
            this.locationRepository = locationRepository;
        }

        public List<IGrouping<string?, Booking>> GetMostVisitedPlaces()
        {
            return context.Bookings
                    .Where(h => h.RoomId != null && h.Room.Hotel.Location.City != null)
                    .GroupBy(o => o.Room.Hotel.Location.City)
                    .ToList()
                    .OrderByDescending(group => group.Count())
                    .Take(6)
                    .ToList();
        }
    }
}
