using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        public Task<List<Hotel>> GetByPageAsync(int pageNumber, int pageSize);
        public Task<Hotel> GetByIdIncludeLocationAsync(int? id);
        public ValueTask<Hotel?> GetHotelById(int id);
        public Task<int> GetCountAsync();
        public List<Hotel> GetHotelsByCity(string city);
       
    }
}
