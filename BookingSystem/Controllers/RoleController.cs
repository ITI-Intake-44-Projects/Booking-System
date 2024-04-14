using BookingSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> RoleManager)
        {
            roleManager = RoleManager;
        }

        public IActionResult AddRole()
        {
            
            ViewBag.Roles = roleManager.Roles.Select(x => x.Name).ToList();
            return View("AddRole");
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel newRoleVM)
        {
            if (ModelState.IsValid == true)
            {
                IdentityRole roleModel = new IdentityRole()
                {
                    Name = newRoleVM.RoleName
                };
                IdentityResult rust = await roleManager.CreateAsync(roleModel);

            }
            return RedirectToAction("AddRole");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRole(RoleViewModel newRoleVM)
        {
            if (newRoleVM.RoleName != null)
            {
                IdentityRole role = await roleManager.FindByNameAsync(newRoleVM.RoleName);
                if (role != null)
                {
                    IdentityResult rust = await roleManager.DeleteAsync(role);
                }
            }
            return RedirectToAction("AddRole");
        }

    }
}
