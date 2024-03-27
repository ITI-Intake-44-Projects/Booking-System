using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public interface ILocationRepository :IRepository<Location>
    {
        public List<string> GetDistinctCountries();
        public List<string> GetCities();
    }
}
