using BookingSystem.Models;
using BookingSystem.ViewModels;

namespace BookingSystem.Repository
{
    public interface IBookingRepository
    {
        public List<IGrouping<string?, Booking>> GetMostVisitedPlaces();
    }
}