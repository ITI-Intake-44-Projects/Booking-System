using AutoMapper;
using BookingSystem.Models;
using BookingSystem.Repository;
using BookingSystem.ViewModels;
using Humanizer.Bytes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
namespace BookingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMapper Mapper;
        private readonly ILocationRepository location;

        public AccountController(UserManager<ApplicationUser> UserManager,SignInManager<ApplicationUser> SignInManager,IMapper mapper,ILocationRepository _Location)
        {
            userManager = UserManager;
            signInManager = SignInManager;
            Mapper = mapper;
            location = _Location;
        }
        public IActionResult Index()
        {
            return View("Register");
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegisterUserVM userVm = new RegisterUserVM();
            userVm.Cities = location.GetCities();
            userVm.Countires = location.GetDistinctCountries();
            return View("Register",userVm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserVM userVM)
        {
            if(ModelState.IsValid == true)
            {
                ApplicationUser user = Mapper.Map<RegisterUserVM, ApplicationUser>(userVM);
                IdentityResult result = await userManager.CreateAsync(user, userVM.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Login");
                }

                foreach (var item in result.Errors)
                    ModelState.AddModelError("", item.Description);
            }

            userVM.Cities = location.GetCities();
            userVM.Countires = location.GetDistinctCountries();
            return View("Register",userVM);
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

                        return Content("Logged in successfully :)");


                    }
                }
                ModelState.AddModelError("", "Invalid Account Credientials");
            }
            return View("Login" ,viewModel);
        }

        public IActionResult Details(ApplicationUser Appuser)
        {

          

            return View("Details");
        }
    }
}
