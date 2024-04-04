using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public interface INonHotelRepository : IRepository<NonHotel>
    {
        public List<NonHotel> GetNonHotelsByCity(string city);
        public List<NonHotel> GetNonHotelsByType(string city, string type);
    }
}
