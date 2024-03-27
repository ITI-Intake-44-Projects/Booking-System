using AutoMapper;
using BookingSystem.Models;
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

        public AccountController(UserManager<ApplicationUser> UserManager,SignInManager<ApplicationUser> SignInManager,IMapper mapper)
        {
            userManager = UserManager;
            signInManager = SignInManager;
            Mapper = mapper;
        }
        public IActionResult Index()
        {
            return View("Register");
        }

        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserVM userVM)
        {
            if(ModelState.IsValid == true)
            {
                byte[] byteImage = null;
                if (userVM.Image != null && userVM.Image.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await userVM.Image.CopyToAsync(memoryStream);
                        byteImage = memoryStream.ToArray();
                    }
                }
                //ApplicationUser user = new ApplicationUser();
               // CreateMap<RegisterUserVM, ApplicationUser>;
                ApplicationUser user = Mapper.Map<RegisterUserVM,ApplicationUser>(userVM);
                //{
                //    UserName = userVM.UserName,
                //    Email = userVM.Email,
                //    PhoneNumber = userVM.PhoneNumber,
                //    FirstName = userVM.FirstName,
                //    LastName = userVM.LastName,
                //    City = userVM.City,
                //    Country = userVM.Country,
                //    Image = byteImage,
                //    PasswordHash = userVM.Password,
                //    Address = userVM.Address,
                //};
                IdentityResult result = await userManager.CreateAsync(user, userVM.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Login");
                }

                foreach (var item in result.Errors)
                    ModelState.AddModelError("", item.Description);
            }

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

                        //string imageBase64 = Convert.ToBase64String(applicationUser.Image);

                        //RegisterUserVM user = new RegisterUserVM()
                        //{
                        //    UserName = applicationUser.UserName,
                        //    Email = applicationUser.Email,
                        //    PhoneNumber = applicationUser.PhoneNumber,
                        //    FirstName = applicationUser.FirstName,
                        //    LastName = applicationUser.LastName,
                        //    City = applicationUser.City,
                        //    Country = applicationUser.Country,
                        //    Password = applicationUser.PasswordHash,
                        //    Address = applicationUser.Address,
                        //    Image = imageBase64
                        //};

                       // return View("Details",user);
                       //return RedirectToAction("Details");
                    }
                }
                ModelState.AddModelError("", "Invalid Account Credientials");
            }
            return View("Login" ,viewModel);
        }

        public IActionResult Details(ApplicationUser Appuser)
        {
            RegisterUserVM user = new RegisterUserVM()
            {
                UserName = Appuser.UserName,
                Email = Appuser.Email,
                PhoneNumber = Appuser.PhoneNumber,
                FirstName = Appuser.FirstName,
                LastName = Appuser.LastName,
                City = Appuser.City,
                Country = Appuser.Country,
                Password = Appuser.PasswordHash,
                Address = Appuser.Address,
            };

            return View("Details",user);
        }
    }
}
