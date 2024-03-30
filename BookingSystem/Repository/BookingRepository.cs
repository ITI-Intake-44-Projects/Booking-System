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
            //var temp = context.Bookings
            //        .Where(h => h.RoomId != null && h.Room.Hotel.Location.City != null)
            //        .GroupBy(o => o.Room.Hotel.Location.City)
            //        .OrderByDescending(group => group.Count());


            //return temp.Select(group => new MostVisitedPlacesViewModel{
            //            CityName = group.Key,
            //            Visits = group.Count(),
            //            CityImage = locationRepository.GetCityImage(group.Key)
            //        }).Take(5).ToList();

            var ret = context.Bookings
                    .Where(h => h.RoomId != null && h.Room.Hotel.Location.City != null)
                    .GroupBy(o => o.Room.Hotel.Location.City)
                    .ToList()
                    .OrderByDescending(group => group.Count())
                    .Take(5).ToList();
            return ret;
        }
    }
}
