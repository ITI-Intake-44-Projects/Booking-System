using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repository
{
    public class NonHotelRepository : Repository<NonHotel>,INonHotelRepository
    {
        public NonHotelRepository(BookingContext _context) :base(_context)
        {
            
        }
        public Task<int> GetCountAsync()
        {
            return context.NonHotels.CountAsync();
        }
        public Task<List<NonHotel>> GetByPageAsync(int pageNumber, int pageSize)
        {
            return context.NonHotels.OrderBy(h => h.NonHotelId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public List<NonHotel> GetNonHotelsByCity(string city)
        {
            return context.NonHotels.Where(h=>h.Location.City == city).ToList();
        }
        public List<NonHotel> GetNonHotelsByType(string type , string city)
        {
            return context.NonHotels.Where(h => h.Location.City == city && h.Type == type).ToList();
        }

    }
}
