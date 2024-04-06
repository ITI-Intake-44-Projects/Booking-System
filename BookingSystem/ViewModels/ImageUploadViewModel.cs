using Microsoft.AspNetCore.Mvc.Rendering;
using Mono.TextTemplating;

namespace BookingSystem.ViewModels
{
    public class ImageUploadViewModel
    {
        public IFormFile ImageFile { get; set; }

        public string SelectedCity { get; set; }

        public List<string> CityList { get; set; }
    }
}
