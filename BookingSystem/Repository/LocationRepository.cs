using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(BookingContext _context) : base(_context)
        {

        }

        public List<string> GetDistinctCountries()
        {
            return context.Locations.Select(l => l.Country).Distinct().ToList();
        }

        public List<string> GetCities()
        {
            return context.Locations.Select(l => l.City).ToList();

        }
    }
}
