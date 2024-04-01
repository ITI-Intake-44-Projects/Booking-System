using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public class HotelRepository : Repository<Hotel>,IHotelRepository
    {
        public HotelRepository(BookingContext _context) :base(_context)
        {
            
        }

        public List<Hotel> GetHotelsByCity(string city)
        {
            return context.Hotels.Where(h=>h.Location.City == city).ToList();
        }
    }
}
