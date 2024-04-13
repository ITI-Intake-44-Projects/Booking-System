using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public interface INonHotelRepository : IRepository<NonHotel>
    {
        public Task<List<NonHotel>> GetByPageAsync(int pageNumber, int pageSize);
        public Task<int> GetCountAsync();
        public List<NonHotel> GetNonHotelsByCity(string city);
        public List<NonHotel> GetNonHotelsByType(string city, string type);
    }
}
