using BookingSystem.Models;
using BookingSystem.ViewModels;
using System.Text;

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

        public string GetCountryByCityName(string cityName)
        {
            return context.Locations.Where(loc => loc.City == cityName)
                                    .Select(loc => loc.Country)
                                    .FirstOrDefault();
        }
        
        public List<string> GetCitiesByCountryName(string country)
        {
            return context.Locations.Where(loc => loc.Country == country).Select(l => l.City).ToList();
        }

        public string GetCityImage(string cityName)
        {
            var cityImg = context.Locations.Where(c => c.City == cityName).Select(c => c.CityImage).FirstOrDefault();
            if (cityImg == null) return null;
            return Convert.ToBase64String(cityImg);
        }

        public List<json_image_data> GetImagesByCountryName(string country = "All")
        {
            var bytes = new List<json_image_data>();

            if (country == "All") {
                bytes = context.Locations.Where(l=>l.CityImage!=null).Select(l => new json_image_data { _image = Convert.ToBase64String(l.CityImage), _name = l.City })
                                         .Take(3).ToList();
            } 
            else {
                bytes = context.Locations.Where(loc => loc.Country == country && loc.CityImage!=null)
                                         .Select(l => new json_image_data { _image = Convert.ToBase64String(l.CityImage), _name = l.City })
                                         .Take(2).ToList();
            }

            var ret = new List<json_image_data>();
            foreach(var record in bytes)
            {
                if (record._image != null)
                {
                    ret.Add(record);
                }
            }
            return ret;
        }

    }
}
