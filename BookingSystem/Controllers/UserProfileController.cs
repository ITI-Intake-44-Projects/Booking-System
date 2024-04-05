using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BookingSystem.Models;
using BookingSystem.ViewModels;
using AutoMapper;

namespace BookingSystem.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserProfileController(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
            {
            var user = await _userManager.GetUserAsync(User);
            var viewModel = _mapper.Map<UserProfileViewModel>(user);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(UserProfileViewModel viewModel)
        {
            var user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                
                byte[] originalImage = null;

                // If the user didn't provide a new image, keep the existing one
                if (viewModel.ImageForm == null || viewModel.ImageForm.Length == 0)
                {
                   originalImage = user.Image;
                }

                // Map properties from view model to model
                _mapper.Map(viewModel, user);
                if (originalImage != null) { 
                user.Image = originalImage;
                }
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            user = await _userManager.GetUserAsync(User);
            viewModel = _mapper.Map<UserProfileViewModel>(user);
            return View("Index", viewModel);
        }
    }
}
