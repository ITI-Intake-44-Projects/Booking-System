using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        public List<Hotel> GetHotelsByCity(string city);
       
    }
}
