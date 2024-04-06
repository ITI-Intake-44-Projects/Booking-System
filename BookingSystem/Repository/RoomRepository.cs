using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public class RoomRepository : Repository<Room>,IRoomRepository
    {
        public RoomRepository(BookingContext context) : base(context)
        {
           
        }

        public List<Room> GetRoomsByHotel(int id)
        {
            return context.Rooms.Where(r => r.Hotel.HotelId == id && r.Reserved != true).ToList();
        }



    }
}
