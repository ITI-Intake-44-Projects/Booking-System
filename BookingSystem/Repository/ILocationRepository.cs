using BookingSystem.Models;
using BookingSystem.ViewModels;

namespace BookingSystem.Repository
{
    public interface ILocationRepository :IRepository<Location>
    {
        public List<string> GetDistinctCountries();
        public List<string> GetCities();


        public string GetCityImage(string cityName);
        public string GetCountryByCityName(string cityName);
        public List<string> GetCitiesByCountryName(string country);
        public List<json_image_data> GetImagesByCountryName(string country);
    }
}
