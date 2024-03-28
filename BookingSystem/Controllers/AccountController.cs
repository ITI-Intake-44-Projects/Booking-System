using BookingSystem.Models;
using BookingSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                 ApplicationUser applicationUser = await userManager.FindByEmailAsync(viewModel.Email);
                if (applicationUser != null)
                {
                    bool userExists = await userManager.CheckPasswordAsync(applicationUser, viewModel.Password);
                    if (userExists)
                    {
                        await signInManager.SignInAsync(applicationUser, viewModel.RememberMe);
                        return  Content("Logged in successfully :) ");
                    }
                }
                ModelState.AddModelError("", "Invalid Account Credientials");
            }
            return View("Login" ,viewModel);
        }
    }
}
