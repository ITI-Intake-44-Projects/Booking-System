using BookingSystem.Models;
using BookingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingSystem.Controllers
{
    public class ImageController : Controller
    {
        private readonly BookingContext _context;

        public ImageController(BookingContext context)
        {
            _context = context;
        }

        public IActionResult UploadImage()
        {
            var viewModel = new ImageUploadViewModel
            {
                CityList = _context.Locations.Select(loc => loc.City).ToList(),
            };
            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> UploadImage(ImageUploadViewModel viewModel)
        {
            if (viewModel.ImageFile == null || viewModel.ImageFile.Length == 0)
                return BadRequest("No image uploaded.");

            using (var memoryStream = new MemoryStream())
            {
                await viewModel.ImageFile.CopyToAsync(memoryStream);
                var record = _context.Locations.FirstOrDefault(loc => loc.City == viewModel.SelectedCity);
                record.CityImage = memoryStream.ToArray();
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Home");
        }
    }

}
