﻿using BookingSystem.Models;
using BookingSystem.ViewModels;
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

        public AccountController(UserManager<ApplicationUser> UserManager,SignInManager<ApplicationUser> SignInManager)
        {
            userManager = UserManager;
            signInManager = SignInManager;
        }
        public IActionResult Index()
        {
            return View();
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
                //if (userVM.Image != null && userVM.Image.ContentLength > 0)
                //{
                //    using (var binaryReader = new BinaryReader(model.ImageFile.InputStream))
                //    {
                //        imageData = binaryReader.ReadBytes(model.ImageFile.ContentLength);
                //    }
                //}
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = userVM.UserName,
                    Email = userVM.Email,
                    PhoneNumber = userVM.PhoneNumber,
                    FirstName = userVM.FirstName,
                    LastName = userVM.LastName,
                    City = userVM.City,
                    Country = userVM.Country,
                    //Image = fi,
                    PasswordHash = userVM.Password,
                    Address = userVM.Address,
                };
                IdentityResult result = await userManager.CreateAsync(user,userVM.Password);

                if (result.Succeeded) 
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index");
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
                        return  Content("Logged in successfully :)");
                    }
                }
                ModelState.AddModelError("", "Invalid Account Credientials");
            }
            return View("Login" ,viewModel);
        }
    }
}
