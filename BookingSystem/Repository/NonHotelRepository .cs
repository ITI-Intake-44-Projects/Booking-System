using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public class NonHotelRepository : Repository<NonHotel>,INonHotelRepository
    {
        public NonHotelRepository(BookingContext _context) :base(_context)
        {
            
        }

        public List<NonHotel> GetNonHotelsByCity(string city)
        {
            return context.NonHotels.Where(h=>h.Location.City == city).ToList();
        }
    }
}
