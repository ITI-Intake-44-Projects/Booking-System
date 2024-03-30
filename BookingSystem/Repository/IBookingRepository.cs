using BookingSystem.ViewModels;

namespace BookingSystem.Repository
{
    public interface IBookingRepository
    {
        public List<MostVisitedPlacesViewModel> GetMostVisitedPlaces();

    }
}