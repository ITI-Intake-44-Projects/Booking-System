using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace BookingSystem.Repository
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        public HotelRepository(BookingContext _context) : base(_context)
        {
        }
            
        public Task<int> GetCountAsync()
        {
            return context.Hotels.CountAsync();
        }

        public Task<List<Hotel>> GetByPageAsync(int pageNumber, int pageSize)
        {
            return context.Hotels.OrderBy(h => h.HotelId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public Task<Hotel> GetByIdIncludeLocationAsync(int? id)
        {
            return context.Hotels.Include(h => h.Location).FirstOrDefaultAsync(m => m.HotelId == id);
        }
        public ValueTask<Hotel?> GetHotelById(int id)
        {
            return context.Hotels.FindAsync(id);
        }

        public List<Hotel> GetHotelsByCity(string city)
        {
            return context.Hotels.Where(h => h.Location.City == city).ToList();
        }
    }
}
