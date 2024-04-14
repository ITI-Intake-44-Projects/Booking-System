using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public interface IRoomRepository : IRepository<Room>
    {
        public List<Room> GetRoomsByHotel(int id);


    }
}
